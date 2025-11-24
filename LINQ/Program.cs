using LINQ.Entities;
using LINQ.Enums;

namespace LINQExercises;
class Program
{
    static void Main(string[] args)
    {
        #region Basic Operations & Aggregations (Q1-Q10)
          // Q1. Find the total value of all products in stock (price × quantity)
          var totalValueInStock = ListGenerator.ProductList.Sum(p => p.UnitPrice * p.UnitsInStock);

          // Q2. Get the first product whose price exceeds the average product price
          var averagePrice = ListGenerator.ProductList.Average(p => p.UnitPrice);
          var firstExceededAveragePrice = ListGenerator.ProductList.FirstOrDefault(p => p.UnitPrice > averagePrice);

          // Q3. Check if there are any employees currently inactive
          var isThereInactiveEmployee = ListGenerator.EmployeeList.Any(e => !e.IsActive);

          // Q4.Retrieve the first 5 books ordered alphabetically by title
          var topOrderedBooks = ListGenerator.BookList.OrderBy(b => b.Title).Take(5);

          // Q5. Return all unique countries where customers live
          var uniqueCountries = ListGenerator.CustomerList.Select(c => c.Country).Distinct();

          // Q6. Find all employees who have been hired within the last 3 years
          var hiredWithinLastThreeYears = ListGenerator.EmployeeList.Where(e => e.HireDate >= DateTime.Now.AddYears(-3) && e.HireDate <= DateTime.Now);

          // Q7. Find all customers who have placed orders worth more than 1000 in total
          var customerOrdersMoreThan1000 = ListGenerator.CustomerList.Where(c => c.Orders is not null && c.Orders.Sum(o => o.Total) > 1000);

          // Q8. Count how many books are out of stock or unavailable
          var outOfStockBooks = ListGenerator.BookList.Count(b => !b.IsAvailable);

          // Q9. Calculate the average salary of employees in each department
          var categorizedAverageSalary = ListGenerator.EmployeeList
            .GroupBy(e => e.Department)
            .Select(g => new
          {
              Department = g.Key,
              AverageSalary =  g.Average(e => e.Salary)
          });

          // Q10. Find the top 3 most expensive products in each category
          var categorizedTopExpensiveProducts = ListGenerator.ProductList
              .GroupBy(p => p.Category)
              .Select(g => new
              {
                  Category = g.Key,
                  topExpensiveProducts = g.OrderByDescending(p => p.UnitPrice).Take(3)
              });
        #endregion

        #region Filtering & Joins (Q11-Q20)
        // Q11. Get all employees who have worked on more than one project
        var employeesHaveMultipleProjects = ListGenerator.EmployeeProjectList
              .GroupBy(ep => ep.EmployeeId)
              .Where(g => g.Count() > 1)
              .Select(g => ListGenerator.EmployeeList.First(e => e.Id == g.Key));

        // Q12. Find the total hours assigned per project and order them descending
        var totalAssignedHours = ListGenerator.EmployeeProjectList
            .GroupBy(p => p.ProjectId).Select(g => new
          {
              ProjectId = g.Key, 
              TotalHours = g.Sum(p => p.HoursAllocated)
          })
            .OrderByDescending(p => p.TotalHours);

        //  Q13. Retrieve all projects that started after the company's average project start date
        var avgTicks = (long) ListGenerator.ProjectList.Average(p => p.StartDate.Ticks);
        var projectsAfterAverage = ListGenerator.ProjectList.Where(p => p.StartDate > new DateTime(avgTicks));

        // Q14. Find all employees who borrowed books from at least two different genres
        var mappedEmployees = ListGenerator.EmployeeList.ToDictionary(e => e.Id, e => e);
          var genresById = ListGenerator.BookList.ToDictionary(b => b.Id, b => b.Genre);


          var groupedEmployees = ListGenerator.BookLoanList.GroupBy(b => b.EmployeeId);
          var multiGenreEmployees = new List<Employee>();

          foreach (var group in groupedEmployees)
          {
          var EmployeeGenre = new HashSet<BookGenre>();
              foreach (var bookLoan in group)
              {
                genresById.TryGetValue(bookLoan.BookId, out var genre);
                  EmployeeGenre.Add(genre);
                 if (EmployeeGenre.Count >= 2)
                  {
                      mappedEmployees.TryGetValue(bookLoan.EmployeeId, out var employee);

                      if (employee is not null)
                      multiGenreEmployees.Add(employee);

                      break;
                  }
              }
          }

          // Q15. Return the project with the longest duration(EndDate - StartDate)
          var longestProject = ListGenerator.ProjectList
            .OrderByDescending(p => p.EndDate - p.StartDate)
            .FirstOrDefault();

          //  Q16. Find all customers who have placed at least one order every quarter of 2024
          var customers = new List<Customer>();
          foreach (var customer in ListGenerator.CustomerList)
          {
              var quarters = new HashSet<int>();

            if (customer is null || customer.Orders is null) continue;
            foreach (var order in customer.Orders)
              {
                  if (order.Date.Year == 2024)
                  {
                      quarters.Add((order.Date.Month - 1) / 3 + 1);
                  }
              if (quarters.Count == 4)
              {
                  customers.Add(customer);
                    break;
                }
              }
          }

        //  Q17. Calculate the total number of books borrowed per month
        var booksPerMonth = ListGenerator.BookLoanList
              .GroupBy(bl => new { bl.LoanDate.Year, bl.LoanDate.Month })
              .Select(bl => new
              {
                  bl.Key.Year,
                  bl.Key.Month,
                  TotalBorrowed = bl.Count()
              });

          // Q18.Retrieve all employees who have both active and inactive project assignments
          var employees = ListGenerator.EmployeeList
              .Where(e =>
                   ListGenerator.EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && ep.IsActive) &&
                   ListGenerator.EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && !ep.IsActive)
              );

          // Q19.Get all projects where every assigned employee is active
          var projects = ListGenerator.ProjectList
            .Where(p =>
                 ListGenerator.EmployeeProjectList
                 .Where(ep => ep.ProjectId == p.Id)
                 .All(ep => ep.IsActive)
            );

        // Q20. Find employees who have worked as both 'Lead' and 'Developer' on different projects
        var leadAndDeveloperEmployees = ListGenerator.EmployeeList
         .Where(e =>
        ListGenerator.EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && ep.Role == ProjectRole.Lead) &&
        ListGenerator.EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && ep.Role == ProjectRole.Developer)
         );

        foreach (var emp in leadAndDeveloperEmployees)
        {
            Console.WriteLine($"Employee Id: {emp.Id}, Name: {emp.Name}");
        }
        #endregion

        #region Advanced Grouping & Calculations (Q21-Q30)
        // Q21. Find the employee with the highest total allocated project hours
        var employeeWithMaxAllocatedHours = ListGenerator.EmployeeProjectList
            .GroupBy(ep => ep.EmployeeId)
            .Select(g => new
            {
                EmployeeId = g.Key,
                HoursAllocated = g.Sum(ep => ep.HoursAllocated)
            }
            )
            .OrderByDescending(ep => ep.HoursAllocated).FirstOrDefault();

        // Q22. Get all employees whose total project hours exceed the company's average
        var totals = ListGenerator.EmployeeProjectList
           .GroupBy(ep => ep.EmployeeId)
           .ToDictionary(
               g => g.Key,
               g => g.Sum(ep => ep.HoursAllocated)
           );

        var avgAllocatedHours = totals.Values.Average();

        var employeesExceedingAvgHours = ListGenerator.EmployeeList
            .Where(e => totals.TryGetValue(e.Id, out var hours) && hours > avgAllocatedHours);

        // Q23. Return the top 3 book genres based on total borrowed count
        var bookGenres = ListGenerator.BookList.ToDictionary(b => b.Id, b => b.Genre);

        var topBookGenres = ListGenerator.BookLoanList
            .Where(bl => bookGenres.ContainsKey(bl.BookId))          
            .Select(bl => bookGenres[bl.BookId])                   
            .GroupBy(genre => genre)
            .Select(g => new { Genre = g.Key, BorrowedCount = g.Count() })
            .OrderByDescending(g => g.BorrowedCount)
            .Take(3)
            .ToList();

        // Q24.Find all employees who have never borrowed a book
        var borrowedEmployeeIds = ListGenerator.BookLoanList.Select(bl => bl.EmployeeId).ToHashSet();
        var employeesNeverBorrowed = ListGenerator.EmployeeList.Where(e => !borrowedEmployeeIds.Contains(e.Id)).ToList();

        // Q25. Determine if all employees in the IT department are active
        var allITActive = ListGenerator.EmployeeList
            .Where(e => e.Department == Department.IT)
            .All(e => e.IsActive);

        //  Q26. Get the average rating of books borrowed by employees with more than 5 years of experience
        var bookRating = ListGenerator.BookList.ToDictionary(b => b.Id, b => b.Rating);
        var experiencedEmployeeIds = ListGenerator.EmployeeList
            .Where(e => e.YearsOfExperience > 5 && borrowedEmployeeIds.Contains(e.Id)).Select(e => e.Id).ToHashSet();

        var employeeAverageRating = ListGenerator.BookLoanList.Where(bl => experiencedEmployeeIds.Contains(bl.EmployeeId)).GroupBy(bl => bl.EmployeeId).Select(g => new
        {
            g.Key,
            AverageRating = g.Average(bl => bookRating.GetValueOrDefault(bl.BookId))
        }).ToList();

        // Q27. Find the difference between the highest and lowest total project budgets
        var minBudget = ListGenerator.ProjectList.Min(p => p.Budget);
        var maxBudget = ListGenerator.ProjectList.Max(p => p.Budget);
        var budgetDifference = maxBudget - minBudget;

        // Q28. Retrieve the employees whose project hours fall within the top 10%
        var totalHoursPerEmployee = ListGenerator.EmployeeProjectList.GroupBy(ep => ep.EmployeeId).Select(g => new
        {
            Employee = mappedEmployees.GetValueOrDefault(g.Key),
            TotalHoursAllocated = g.Sum(ep => ep.HoursAllocated)
        }).OrderByDescending(a => a.TotalHoursAllocated)
          .ToList();

        var topCount = (int)Math.Ceiling(totalHoursPerEmployee.Count * 0.1);
        var top10Percent = totalHoursPerEmployee.Take(topCount);

        // Q29. Return all books borrowed by employees working on 'AI' category projects
        var projectCategories = ListGenerator.ProjectList.ToDictionary(p => p.Id, p => p.Category);

        var aiEmployees = ListGenerator.EmployeeProjectList
            .Where(ep => projectCategories[ep.ProjectId] == ProjectCategory.AI_ML)
            .Select(ep => ep.EmployeeId)
            .ToHashSet();

        var booksById = ListGenerator.BookList.ToDictionary(b => b.Id, b => b);
        var booksBorrowedByAIEmployees = ListGenerator.BookLoanList
            .Where(bl => aiEmployees.Contains(bl.EmployeeId))
            .Select(bl => booksById.GetValueOrDefault(bl.BookId))
            .Where(book => book != null)
            .ToList();

        // Q30. Count how many customers have placed orders in both 2024 and 2025
        var customersCountIn2024And2025 = ListGenerator.CustomerList.Count(c => 
        c.Orders is not null &&
        c.Orders.Any(o => o.Date.Year == 2024) && 
        c.Orders.Any(o => o.Date.Year == 2025));
        #endregion
    }
}