using LINQ.Entities;
using LINQ.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

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
          var mappedBooks = ListGenerator.BookList.ToDictionary(b => b.Id, b => b.Genre);


          var groupedEmployees = ListGenerator.BookLoanList.GroupBy(b => b.EmployeeId);
          var multiGenreEmployees = new List<Employee>();

          foreach (var group in groupedEmployees)
          {
          var EmployeeGenre = new HashSet<BookGenre>();
              foreach (var bookLoan in group)
              {
                  mappedBooks.TryGetValue(bookLoan.BookId, out var genre);
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



    }
}