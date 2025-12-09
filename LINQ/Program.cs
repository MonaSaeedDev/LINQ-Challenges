using LINQ.Entities;
using LINQ.Enums;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using static LINQ.Entities.ListGenerator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQExercises;
class Program
{
    static void Main(string[] args)
    {
        #region Basic Operations & Aggregations (Q1-Q10)
        // Q1. Find the total value of all products in stock (price × quantity)
        var totalValueInStock = ProductList.Sum(p => p.UnitPrice * p.UnitsInStock);

        // Q2. Get the first product whose price exceeds the average product price
        var averagePrice = ProductList.Average(p => p.UnitPrice);
        var firstExceededAveragePrice = ProductList.FirstOrDefault(p => p.UnitPrice > averagePrice);

        // Q3. Check if there are any employees currently inactive
        var isThereInactiveEmployee = EmployeeList.Any(e => !e.IsActive);

        // Q4.Retrieve the first 5 books ordered alphabetically by title
        var topOrderedBooks = BookList.OrderBy(b => b.Title).Take(5);

        // Q5. Return all unique countries where customers live
        var uniqueCountries = CustomerList.Select(c => c.Country).Distinct();

        // Q6. Find all employees who have been hired within the last 3 years
        var hiredWithinLastThreeYears = EmployeeList.Where(e => e.HireDate >= DateTime.Now.AddYears(-3) && e.HireDate <= DateTime.Now);

        // Q7. Find all customers who have placed orders worth more than 1000 in total
        var customerOrdersMoreThan1000 = CustomerList.Where(c => c.Orders is not null && c.Orders.Sum(o => o.Total) > 1000);

        // Q8. Count how many books are out of stock or unavailable
        var outOfStockBooks = BookList.Count(b => !b.IsAvailable);

        // Q9. Calculate the average salary of employees in each department
        var categorizedAverageSalary = EmployeeList
          .GroupBy(e => e.Department)
          .Select(g => new
          {
              Department = g.Key,
              AverageSalary = g.Average(e => e.Salary)
          });

        // Q10. Find the top 3 most expensive products in each category
        var categorizedTopExpensiveProducts = ProductList
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                topExpensiveProducts = g.OrderByDescending(p => p.UnitPrice).Take(3)
            });
        #endregion

        #region Filtering & Joins (Q11-Q20)
        // Q11. Get all employees who have worked on more than one project
        var employeesHaveMultipleProjects = EmployeeProjectList
              .GroupBy(ep => ep.EmployeeId)
              .Where(g => g.Count() > 1)
              .Select(g => EmployeeList.First(e => e.Id == g.Key));

        // Q12. Find the total hours assigned per project and order them descending
        var totalAssignedHours = EmployeeProjectList
            .GroupBy(p => p.ProjectId).Select(g => new
            {
                ProjectId = g.Key,
                TotalHours = g.Sum(p => p.HoursAllocated)
            })
            .OrderByDescending(p => p.TotalHours);

        //  Q13. Retrieve all projects that started after the company's average project start date
        var avgTicks = (long)ProjectList.Average(p => p.StartDate.Ticks);
        var projectsAfterAverage = ProjectList.Where(p => p.StartDate > new DateTime(avgTicks));

        // Q14. Find all employees who borrowed books from at least two different genres
        var mappedEmployees = EmployeeList.ToDictionary(e => e.Id, e => e);
        var genresById = BookList.ToDictionary(b => b.Id, b => b.Genre);


        var groupedEmployees = BookLoanList.GroupBy(b => b.EmployeeId);
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
        var longestProject = ProjectList
          .OrderByDescending(p => p.EndDate - p.StartDate)
          .FirstOrDefault();

        //  Q16. Find all customers who have placed at least one order every quarter of 2024
        var customers = new List<Customer>();
        foreach (var customer in CustomerList)
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
        var booksPerMonth = BookLoanList
              .GroupBy(bl => new { bl.LoanDate.Year, bl.LoanDate.Month })
              .Select(bl => new
              {
                  bl.Key.Year,
                  bl.Key.Month,
                  TotalBorrowed = bl.Count()
              });

        // Q18.Retrieve all employees who have both active and inactive project assignments
        var employees = EmployeeList
            .Where(e =>
                 EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && ep.IsActive) &&
                 EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && !ep.IsActive)
            );

        // Q19.Get all projects where every assigned employee is active
        var projects = ProjectList
          .Where(p =>
               EmployeeProjectList
               .Where(ep => ep.ProjectId == p.Id)
               .All(ep => ep.IsActive)
          );

        // Q20. Find employees who have worked as both 'Lead' and 'Developer' on different projects
        var leadAndDeveloperEmployees = EmployeeList
         .Where(e =>
        EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && ep.Role == ProjectRole.Lead) &&
        EmployeeProjectList.Any(ep => ep.EmployeeId == e.Id && ep.Role == ProjectRole.Developer)
         );

        foreach (var emp in leadAndDeveloperEmployees)
        {
            Console.WriteLine($"Employee Id: {emp.Id}, Name: {emp.Name}");
        }
        #endregion

        #region Advanced Grouping & Calculations (Q21-Q30)
        // Q21. Find the employee with the highest total allocated project hours
        var employeeWithMaxAllocatedHours = EmployeeProjectList
            .GroupBy(ep => ep.EmployeeId)
            .Select(g => new
            {
                EmployeeId = g.Key,
                HoursAllocated = g.Sum(ep => ep.HoursAllocated)
            }
            )
            .OrderByDescending(ep => ep.HoursAllocated).FirstOrDefault();

        // Q22. Get all employees whose total project hours exceed the company's average
        var totals = EmployeeProjectList
           .GroupBy(ep => ep.EmployeeId)
           .ToDictionary(
               g => g.Key,
               g => g.Sum(ep => ep.HoursAllocated)
           );

        var avgAllocatedHours = totals.Values.Average();

        var employeesExceedingAvgHours = EmployeeList
            .Where(e => totals.TryGetValue(e.Id, out var hours) && hours > avgAllocatedHours);

        // Q23. Return the top 3 book genres based on total borrowed count
        var bookGenres = BookList.ToDictionary(b => b.Id, b => b.Genre);

        var topBookGenres = BookLoanList
            .Where(bl => bookGenres.ContainsKey(bl.BookId))
            .Select(bl => bookGenres[bl.BookId])
            .GroupBy(genre => genre)
            .Select(g => new { Genre = g.Key, BorrowedCount = g.Count() })
            .OrderByDescending(g => g.BorrowedCount)
            .Take(3)
            .ToList();

        // Q24.Find all employees who have never borrowed a book
        var borrowedEmployeeIds = BookLoanList.Select(bl => bl.EmployeeId).ToHashSet();
        var employeesNeverBorrowed = EmployeeList.Where(e => !borrowedEmployeeIds.Contains(e.Id)).ToList();

        // Q25. Determine if all employees in the IT department are active
        var allITActive = EmployeeList
            .Where(e => e.Department == Department.IT)
            .All(e => e.IsActive);

        //  Q26. Get the average rating of books borrowed by employees with more than 5 years of experience
        var bookRating = BookList.ToDictionary(b => b.Id, b => b.Rating);
        var experiencedEmployeeIds = EmployeeList
            .Where(e => e.YearsOfExperience > 5 && borrowedEmployeeIds.Contains(e.Id)).Select(e => e.Id).ToHashSet();

        var employeeAverageRating = BookLoanList.Where(bl => experiencedEmployeeIds.Contains(bl.EmployeeId)).GroupBy(bl => bl.EmployeeId).Select(g => new
        {
            g.Key,
            AverageRating = g.Average(bl => bookRating.GetValueOrDefault(bl.BookId))
        }).ToList();

        // Q27. Find the difference between the highest and lowest total project budgets
        var minBudget = ProjectList.Min(p => p.Budget);
        var maxBudget = ProjectList.Max(p => p.Budget);
        var budgetDifference = maxBudget - minBudget;

        // Q28. Retrieve the employees whose project hours fall within the top 10%
        var totalHoursPerEmployee = EmployeeProjectList.GroupBy(ep => ep.EmployeeId).Select(g => new
        {
            Employee = mappedEmployees.GetValueOrDefault(g.Key),
            TotalHoursAllocated = g.Sum(ep => ep.HoursAllocated)
        }).OrderByDescending(a => a.TotalHoursAllocated)
          .ToList();

        var topCount = (int)Math.Ceiling(totalHoursPerEmployee.Count * 0.1);
        var top10Percent = totalHoursPerEmployee.Take(topCount);

        // Q29. Return all books borrowed by employees working on 'AI' category projects
        var projectCategories = ProjectList.ToDictionary(p => p.Id, p => p.Category);

        var aiEmployees = EmployeeProjectList
            .Where(ep => projectCategories[ep.ProjectId] == ProjectCategory.AI_ML)
            .Select(ep => ep.EmployeeId)
            .ToHashSet();

        var booksById = BookList.ToDictionary(b => b.Id);
        var booksBorrowedByAIEmployees = BookLoanList
            .Where(bl => aiEmployees.Contains(bl.EmployeeId))
            .Select(bl => booksById.GetValueOrDefault(bl.BookId))
            .OfType<Book>()
            .ToList();

        // Q30. Count how many customers have placed orders in both 2024 and 2025
        var customersCountIn2024And2025 = CustomerList.Count(c =>
        c.Orders is not null &&
        c.Orders.Any(o => o.Date.Year == 2024) &&
        c.Orders.Any(o => o.Date.Year == 2025));
        #endregion

        #region Complex Filtering & Comparisons (Q31-Q40)
        // Q31.Find employees who borrowed more books than the average borrowing count per employee
        var employeesById = EmployeeList.ToDictionary(e => e.Id);

        var averageBorrowCount = BookLoanList
                .GroupBy(bl => bl.EmployeeId)
                .Average(g => g.Count());

        var employeesAboveAverage = BookLoanList.GroupBy(bl => bl.EmployeeId)
                .Where(g => g.Count() > averageBorrowCount)
                .Select(g => employeesById.GetValueOrDefault(g.Key)).OfType<Employee>();

        // Q32. Retrieve employees whose manager joined the company after them
        var hireDates = EmployeeList.ToDictionary(e => e.Id, e => e.HireDate);

        var employeesWhoseManagerJoinedLater = EmployeeList
            .Where(e =>
                e.ManagerId is not null &&
                hireDates.ContainsKey(e.ManagerId.Value) &&
                e.HireDate < hireDates[e.ManagerId.Value]).ToList();

        // Q33. Find all books that were borrowed but never returned on time
        var overdueBooks = BookLoanList
            .Where(bl => (bl.IsReturned && bl.ReturnDate > bl.DueDate) || (!bl.IsReturned && DateTime.Now > bl.DueDate))
            .Select(bl => booksById.GetValueOrDefault(bl.BookId))
            .OfType<Book>()
            .ToList();

        // Q34. Return all employees who have projects in two different categories
        var employeesWithTwoOrMoreCategories = EmployeeProjectList
        .GroupBy(ep => ep.EmployeeId)
        .Where(g =>
            {
                var categories = new HashSet<ProjectCategory>();
                foreach (var ep in g)
                {
                    if (projectCategories.TryGetValue(ep.ProjectId, out var category))
                        categories.Add(category);
                }
                return categories.Count >= 2;
            })
        .Select(g => employeesById.GetValueOrDefault(g.Key))
        .OfType<Employee>()
        .ToList();

        // Q35. Calculate the ratio between completed and total projects
        var total = ProjectList.Count;
        var completed = ProjectList.Count(p => p.CompletionPercentage == 100.0);
        var ratio = total == 0 ? 0 : (double)completed / total;

        // Q36. Find the top 3 employees with the highest ratio of total hours to experience years
        var experienceById = EmployeeList.ToDictionary(e => e.Id, e => e.YearsOfExperience);

        var totalHoursById = EmployeeProjectList.GroupBy(ep => ep.EmployeeId)
            .ToDictionary(g => g.Key, g => g.Sum(ep => ep.HoursAllocated));

        var top3Employees = totalHoursById
            .Where(kv => experienceById.GetValueOrDefault(kv.Key) > 0)
            .OrderByDescending(g => (double)totalHoursById.GetValueOrDefault(g.Key) / experienceById.GetValueOrDefault(g.Key))
            .Take(3)
            .Select(g => employeesById.GetValueOrDefault(g.Key));

        // Q37. Return all employees who borrowed all available 'Fantasy' books
        var fantasyBooks = BookList
            .Where(b => b.IsAvailable && b.Genre == BookGenre.Fantasy)
            .Select(b => b.Id)
            .ToHashSet();

        var employeesWhoBorrowedAllFantasy = BookLoanList
            .GroupBy(bl => bl.EmployeeId)
            .Where(g => fantasyBooks.All(bookId => g.Any(bl => bl.BookId == bookId)))
            .Select(g => employeesById.GetValueOrDefault(g.Key))
            .OfType<Employee>()
            .ToList();

        // Q38. Find all employees who borrowed books in at least 3 different months
        var employeesThreeMonthsOrMore = BookLoanList.GroupBy(ep => ep.EmployeeId)
            .Where(g => g.Select(bl => (bl.LoanDate.Year, bl.LoanDate.Month)).ToHashSet().Count >= 3)
            .Select(g => employeesById.GetValueOrDefault(g.Key))
            .OfType<Employee>()
            .ToList();

        // Q39. Return all projects that share at least one employee with another project
        var projectsById = ProjectList.ToDictionary(p => p.Id);

        var grouped = EmployeeProjectList.GroupBy(ep => ep.EmployeeId);

        var sharedProjectIds = new HashSet<int>();

        foreach (var group in grouped)
        {
            if (group.Skip(1).Any())
            {
                foreach (var ep in group)
                    sharedProjectIds.Add(ep.ProjectId);
            }
        }

        var result = sharedProjectIds
            .Select(pid => projectsById.GetValueOrDefault(pid))
            .OfType<Project>()
            .ToList();

        // Q40. Find the employee with the earliest hire date who still manages others
        var managers = EmployeeList.Where(e => e.ManagerId is not null).Select(e => e.ManagerId!.Value).ToHashSet();
        var earliestManager = EmployeeList.Where(e => managers.Contains(e.Id)).OrderBy(e => e.HireDate).FirstOrDefault();
        #endregion

        #region Set Operations & Advanced Queries (Q41-Q50)
        //  Q41. Return books that were borrowed more than the average borrowing frequency
        var loansGroupedByBook = BookLoanList.GroupBy(bl => bl.BookId);
        var averageBorrowFrequency = loansGroupedByBook.Average(g => g.Count());
        var booksBorrowedAboveAverage = loansGroupedByBook.Where(g => g.Count() > averageBorrowFrequency)
                .Select(g => booksById.GetValueOrDefault(g.Key))
                .OfType<Book>()
                .ToList();

        // Q42. Find employees who worked on projects that no longer exist in the system
        var existingProjectIds = ProjectList.Select(p => p.Id).ToHashSet();

        var employeesOnRemovedProjects = EmployeeProjectList
            .Where(ep => !existingProjectIds.Contains(ep.ProjectId))
            .Select(ep => employeesById.GetValueOrDefault(ep.EmployeeId))
            .OfType<Employee>()
            .Distinct();

        // Q43. Return employees who participated in a project that others didn't
        var uniqueProjectEmployees = EmployeeProjectList.Where(ep => ep.IsActive).GroupBy(ep => ep.ProjectId)
            .Where(g => g.Count() == 1).Select(g => employeesById.GetValueOrDefault(g.First().EmployeeId))
            .OfType<Employee>().ToList();

        //  Q44. Retrieve the union of all project categories that contain either AI or Cloud-related work
        var aiOrCloudProjects = ProjectList
            .Where(p => p.Category == ProjectCategory.AI_ML || p.Category == ProjectCategory.Infrastructure)
            .Select(p => p.Category)
            .Distinct();

        // Q45. Find the intersection of employees who borrowed books and those who worked on projects
        var projectEmployeeIds = EmployeeProjectList
            .Select(ep => ep.EmployeeId)
            .ToHashSet();

        var employeesWhoBorrowedAndWorked = BookLoanList
            .Select(bl => bl.EmployeeId)
            .Where(projectEmployeeIds.Contains)
            .Select(id => employeesById.GetValueOrDefault(id))
            .OfType<Employee>();

        // Q46. Check whether two employees have worked on exactly the same set of projects (example: employee 1 and 3)
        int emp1Id = 1;
        int emp2Id = 3;

        var emp1Projects = EmployeeProjectList
            .Where(ep => ep.IsActive && ep.EmployeeId == emp1Id)
            .Select(ep => ep.ProjectId)
            .ToHashSet();

        var emp2Projects = EmployeeProjectList
            .Where(ep => ep.IsActive && ep.EmployeeId == emp2Id)
            .Select(ep => ep.ProjectId)
            .ToHashSet();

        bool sameProjects = emp1Projects.SetEquals(emp2Projects);

        //  Q47. Create a lookup of employees grouped by their manager ID
        var employeesByManager = EmployeeList
            .ToLookup(e => e.ManagerId);

        // Q48. Convert the product list into a dictionary where the key is product ID and the value is product name
        var productDictionary = ProductList.ToDictionary(p => p.Id, p => p.Name);

        //  Q49. Find all products whose stock value ranks within the top 20% of total inventory value
        var topProducts = ProductList.OrderByDescending(p => p.UnitPrice * p.UnitsInStock)
            .Take((int)(Math.Ceiling(ProductList.Count * 0.2)));

        // Q50. Aggregate all project budgets into a single summary string showing 'ProjectName:Budget'
        var projectBudgetSummary = string.Join(", ", ProjectList.Select(p => $"{p.Name}:{p.Budget:C}"));
        #endregion

        #region Orders & Customers (Q51-Q70)
        // Q51.Find customers who have never placed an order
        var customersWithoutOrders = CustomerList.Where(c => c.Orders == null || c.Orders.Length > 0).ToList();

        // Q52. Find all orders with a total greater than the average order total
        var averageTotal = OrderList.Average(o => o.Total);

        var ordersAboveAverage = OrderList
            .Where(o => o.Total > averageTotal)
            .ToList();

        // Q53. Get the most recent order placed by each customer
        var mostRecentOrders = CustomerList
            .Where(c => c.Orders != null && c.Orders.Length != 0)
            .Select(c => new
            {
                Customer = c,
                RecentOrder = c.Orders.OrderByDescending(o => o.Date).First()
            }).ToList();

        // Q54. Count how many products were ordered by each customer
        var productsPerCustomer = CustomerList
            .Select(c => new
            {
                Customer = c,
                TotalProductsOrdered = c.Orders?.Sum(o => o.Products.Count) ?? 0
            })
            .ToList();

        //Q55.Find the top 5 customers by total spending
        var top5Customers = CustomerList
            .Select(c => new
            {
                Customer = c,
                TotalSpending = c.Orders?.Sum(o => o.Total) ?? 0
            })
            .OrderByDescending(c => c.TotalSpending)
            .Take(5)
            .ToList();

        //Q56.Retrieve all orders that include at least one product from the 'Electronics' category
        var electronicsOrders = OrderList
            .Where(o => o.Products.Any(p => p.Category == "Electronics"))
            .ToList();

        //Q57.Calculate the average order total per country
        var avgPerOrder = CustomerList
          .GroupBy(c => c.Country)
          .Select(g =>
          {
              decimal sum = 0;
              int count = 0;

              foreach (var c in g)
              {
                  if (c.Orders is not null)
                      foreach (var o in c.Orders)
                      {
                          sum += o.Total;
                          count++;
                      }
              }

              return new
              {
                  Country = g.Key,
                  AverageOrderTotal = count == 0 ? 0 : sum / count
              };
          })
          .ToList();

        //Q58.Find all customers who placed orders in December only
        var decemberOnlyCustomers = CustomerList.Where(c => c.Orders.Length != 0 && c.Orders.All(o => o.Date.Month == 12));

        // Q59. List all products that were never ordered (High-Performance Version)
        var orderedProducts = new HashSet<Product>();

        foreach (var order in OrderList)
        {
            foreach (var product in order.Products)
            {
                orderedProducts.Add(product);
            }
        }

        var neverOrderedProducts = new List<Product>();

        foreach (var product in ProductList)
        {
            if (!orderedProducts.Contains(product))
                neverOrderedProducts.Add(product);
        }

        //Q60.Find all products where total sales(price × quantity sold) exceed 10,000
        var sales = new Dictionary<long, decimal>();
        foreach (var order in OrderList)
        {
            foreach (var product in order.Products)
            {
                if (sales.TryGetValue(product.Id, out var totalSales))
                {
                    sales[product.Id] = total + product.UnitPrice;
                }
                else
                {
                    sales[product.Id] = product.UnitPrice;
                }
            }
        }

        var highSellingProducts = ProductList.Where(p => sales.ContainsKey(p.Id) && sales[p.Id] > 10_000).ToList();

        //Q61.Find the most frequently ordered product overall
        var salesCount = new Dictionary<long, int>();
        foreach (var order in OrderList)
        {
            foreach (var product in order.Products)
            {
                if (!salesCount.TryAdd(product.Id, 1))
                {
                    salesCount[product.Id]++;
                }
            }
        }

        var maxCount = sales.Values.Max();
        var mostFrequentProducts = ProductList.FirstOrDefault(p => salesCount.TryGetValue(p.Id, out var count) && count == maxCount);

        // Q62. Find customers who have ordered the same product more than once 
        CustomerList
            .Where(c => c.Orders != null && c.Orders.Length != 0)
            .Where(c =>
            {
                var seenProductIds = new HashSet<long>();
                return c.Orders
                .Where(o => o.Products != null)
                .SelectMany(o => o.Products)
                .Any(p => !seenProductIds.Add(p.Id));
            })
            .ToList().ForEach(Console.WriteLine);

        // Q63.Get the month with the highest number of orders
        var topMonth = OrderList
            .Where(o => o is not null && o.Products.Count != 0)
            .GroupBy(o => (o.Date.Year, o.Date.Month))
            .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .FirstOrDefault();

        // Q64. Retrieve the average number of items per order
        var averageItemsPerOrder = OrderList
            .Where(o => o is not null && o.Products.Count != 0)
            .Average(o => o.Products.Count);

        // Q65. Find the earliest and latest order dates for each customer
        var orderDatesPerCustomer = CustomerList
            .Where(c => c.Orders is not null && c.Orders.Length != 0)
            .Select(c => new
            {
                Customer = c,
                EarliestOrderDate = c.Orders.Min(o => o.Date),
                LatestOrderDate = c.Orders.Max(o => o.Date)
            })
            .ToList();

        // Q66. Find all orders placed on weekends
        var weekendOrders = OrderList
            .Where(o => o != null && o.Products.Count != 0)
            .Where(o => o.Date.DayOfWeek == DayOfWeek.Saturday || o.Date.DayOfWeek == DayOfWeek.Sunday)
            .ToList();

        // Q67. Identify customers who placed orders in 2023 but not in 2024
        var customers2023Not2024 = CustomerList
            .Where(c => c.Orders != null
                        && c.Orders.Any(o => o.Date.Year == 2023)
                        && !c.Orders.Any(o => o.Date.Year == 2024)).ToList();

        //  Q68. For each customer, calculate their average order value
        var avgOrderValuePerCustomer = CustomerList
            .Where(c => c.Orders is not null && c.Orders.Length != 0)
            .Select(c => new
            {
                Customer = c,
                AverageOrderValue = c.Orders.Average(o => o.Total)
            })
            .ToList();

        //  Q69.Get the top 3 products per category by total sales
        var productSalesCount = OrderList.SelectMany(o => o.Products).GroupBy(p => p.Id)
            .ToDictionary(g => g.Key, g => g.Count());

        var totalSalesPerProduct = ProductList
            .ToDictionary(
                p => p.Id,
                p => (Product: p, TotalSales: productSalesCount.GetValueOrDefault(p.Id) * p.UnitPrice)
            );

        var topProductsByCategoryOptimized = totalSalesPerProduct.Values
            .GroupBy(x => x.Product.Category)
            .Select(g => new
            {
                Category = g.Key,
                Top3Products = g
                    .OrderByDescending(x => x.TotalSales)
                    .Take(3)
                    .ToList()
            })
            .ToList();

        //Q70.Calculate the total revenue per product category
        var salesCountByProductId = OrderList.SelectMany(o => o.Products).GroupBy(p => p.Id).ToDictionary(g => g.Key, g => g.Count());

        var revenuePerCategory = ProductList.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                TotalRevenue = g.Sum(p => p.UnitPrice * salesCountByProductId.GetValueOrDefault(p.Id))
            }).ToList();

        #endregion

        #region  Books & Library (Q71-Q80)
        // Q71. Get all books never borrowed by anyone
        var borrowedBookIds = BookLoanList.Select(bl => bl.BookId).ToHashSet();
        var booksNeverBorrowed = BookList.Where(b => !borrowedBookIds.Contains(b.Id)).ToList();

        //  Q72. Find all employees who borrowed books more than twice in the same month
        var employeesBorrowedMoreThanTwice = BookLoanList
            .GroupBy(bl => (bl.LoanDate.Year, bl.LoanDate.Month, bl.EmployeeId))
            .Where(g => g.Count() > 2)
            .Select(g => employeesById.GetValueOrDefault(g.Key.EmployeeId))
            .OfType<Employee>()
            .Distinct()
            .ToList();

        // Q73. Calculate the most popular genre among borrowed books
        var mostPopularGenreInfo = BookLoanList
        .Where(bl => bookGenres.ContainsKey(bl.BookId))
        .GroupBy(bl => bookGenres[bl.BookId])
        .Select(g => new
        {
            Genre = g.Key,
            BorrowCount = g.Count()
        })
        .MaxBy(x => x.BorrowCount);

        var mostPopularGenre = mostPopularGenreInfo?.Genre;

        // Q74. Find books borrowed by at least 5 unique employees
        var booksBorrowedByAtLeast5Employees = BookLoanList
            .GroupBy(bl => bl.BookId)
            .Where(g => g.Select(bl => bl.EmployeeId).Distinct().Count() >= 5)
            .Select(g => booksById.GetValueOrDefault(g.Key))
            .OfType<Book>()
            .ToList();

        //  Q75. Determine the average loan duration for returned books
        var averageLoanDuration = BookLoanList
            .Where(bl => bl.IsReturned && bl.ReturnDate.HasValue)
            .Average(bl => (bl.ReturnDate!.Value - bl.LoanDate).TotalDays);

        // Q76. Get all employees who returned a book after more than 30 days
        var employeesWithLateReturns = BookLoanList
            .Where(bl => bl.IsReturned
            && bl.ReturnDate.HasValue
            && (bl.ReturnDate.Value - bl.LoanDate).TotalDays > 30)
            .Select(bl => employeesById.GetValueOrDefault(bl.EmployeeId))
            .OfType<Employee>()
            .Distinct()
            .ToList();

        // Q77. Find the month with the highest number of late returns
        var monthWithMostLateReturns = BookLoanList.Where(bl => bl.IsReturned
            && bl.ReturnDate.HasValue
            && bl.ReturnDate.Value > bl.DueDate) // .Value
            .GroupBy(bl => (bl.ReturnDate!.Value.Year, bl.ReturnDate!.Value.Month))
            .MaxBy(g => g.Count())?.Key.Month;

        // Q78. Find employees who borrowed books of only one genre
        var employeesSingleGenre = BookLoanList.GroupBy(bl => bl.EmployeeId)
            .Select(g => new
            {
                EmployeeId = g.Key,
                Genres = g.Select(bl => bookGenres.GetValueOrDefault(bl.BookId)).OfType<BookGenre>().ToHashSet()
            }).Where(x => x.Genres.Count == 1)
            .Select(x => employeesById.GetValueOrDefault(x.EmployeeId))
            .OfType<Employee>()
            .ToList();

        // Q79. Calculate the total number of currently borrowed books (not returned)
        var totalCurrentlyBorrowedBooks = BookLoanList
            .Count(bl => !bl.IsReturned && !bl.ReturnDate.HasValue);

        //  Q80. Find all employees who borrowed books in both 2023 and 2024
        var employeesBorrowedInBothYears = BookLoanList
            .Where(bl => bl.LoanDate.Year == 2023 || bl.LoanDate.Year == 2024)
            .GroupBy(bl => bl.EmployeeId)
            .Where(g => g.Any(bl => bl.LoanDate.Year == 2023) && g.Any(bl => bl.LoanDate.Year == 2024))
            .Select(g => employeesById.GetValueOrDefault(g.Key))
            .OfType<Employee>()
            .ToList();

        #endregion

        #region Employees & Departments (Q81-Q90)
        // Q81. Find all employees whose salary is below the department average
        var employeesBelowDeptAverage = EmployeeList.GroupBy(e => e.Department)
            .SelectMany(g =>
            {
                var AverageSalary = g.Select(e => e.Salary).Average();
                return g.Where(e => e.Salary < AverageSalary);
            }).ToList();

        // Q82. Find departments with more than 10 employees
        var departmentsWithMoreThan10 = EmployeeList
            .GroupBy(e => e.Department)
            .Where(g => g.Count() > 10)
            .Select(g => g.Key)
            .ToList();

        // Q83. Get the highest paid employee in each department
        var highestPaidPerDept = EmployeeList
            .GroupBy(e => e.Department)
            .Select(g => g.MaxBy(e => e.Salary));

        //  Q84. Find employees who joined in the same year as their manager
        var employeesWithSameHireYearAsManager = EmployeeList
            .Where(e => e.ManagerId.HasValue &&
            employeesById.TryGetValue(e.ManagerId.Value, out var manager) &&
            e.HireDate.Year == manager.HireDate.Year).ToList();

        //  Q85. Count the number of employees hired each year
        var employeesHiredPerYear = EmployeeList.GroupBy(e => e.HireDate.Year).Select(g => new
        {
            Year = g.Key,
            Count = g.Count()
        }).ToList();

        // Q86. Retrieve employees who have never worked on any project
        var employeesWithProjects = EmployeeProjectList
             .Select(ep => ep.EmployeeId)
             .ToHashSet();

        var employeesWithoutProjects = EmployeeList
            .Where(e => !employeesWithProjects.Contains(e.Id))
            .ToList();

        // Q87. Find the department with the highest total salary cost
        var departmentWithHighestSalaryCost = EmployeeList.GroupBy(e => e.Department)
          .MaxBy(g => g.Sum(e => e.Salary))?.Key;

        // Q88. Get all employees whose experience exceeds 10 years and who manage others
        var managerIds = EmployeeList
            .Where(e => e.ManagerId.HasValue)
            .Select(e => e.ManagerId!.Value)
            .ToHashSet();

        var experiencedManagers = EmployeeList
            .Where(e => e.YearsOfExperience > 10 && managerIds.Contains(e.Id))
            .ToList();

        //  Q89. List employees who have no subordinates and no projects
        var employeesWithoutSubordinatesOrProjects = EmployeeList
            .Where(e => !managerIds.Contains(e.Id) && !projectEmployeeIds.Contains(e.Id))
            .ToList();

        // Q90. Find employees who were promoted (i.e., salary increased) — assume a list of SalaryHistory
        /*  var promotedEmployeeIds = SalaryHistory
               .GroupBy(s => s.EmployeeId)
               .Where(g => g.Max(s => s.Salary) != g.Min(s => s.Salary))
               .Select(g => g.Key)
               .ToHashSet();

          var promotedEmployees = EmployeeList
              .Where(e => promotedEmployeeIds.Contains(e.Id))
              .ToList();*/

        #endregion

        #region Projects & Assignments (Q91-Q100)
        // Q91. Find projects that started and ended in the same year
        var projectsSameYear = ProjectList
            .Where(p => p.EndDate.HasValue && p.StartDate.Year == p.EndDate.Value.Year)
            .ToList();

        // Q92. Find the average number of employees per project
        var averageEmployeesPerProject = EmployeeProjectList
            .GroupBy(ep => ep.ProjectId)
            .Select(g => g.Count())
            .DefaultIfEmpty(0)
            .Average();

        // Q93. Get all projects with no assigned employees
        var assignedProjectIds = EmployeeProjectList
             .Select(ep => ep.ProjectId)
             .ToHashSet();

        var projectsWithNoEmployees = ProjectList
            .Where(p => !assignedProjectIds.Contains(p.Id))
            .ToList();

        // Q94. Find the most common project category
        var mostCommonCategory = ProjectList
            .GroupBy(p => p.Category)
            .MaxBy(g => g.Count())?
            .Key;

        // Q95. Calculate the average duration (in days) of all projects
        var averageDuration = ProjectList
            .Where(p => p.EndDate.HasValue)
            .Average(p => (p.EndDate!.Value - p.StartDate).TotalDays);

        // Q96. Find employees who worked on more than 3 projects simultaneously

        // Sweep-line algorithm to track active events and efficiently find overlaps or intersections.
        var employeesWorkedOnMoreThan3Simultaneously = EmployeeProjectList
            .GroupBy(ep => ep.EmployeeId)
            .Where(g =>
            {
                var events = g
                    .Select(ep =>
                    {
                        if (!projectsById.TryGetValue(ep.ProjectId, out var project))
                            return null; 

                        return new
                        {
                            Start = ep.AssignedDate,
                            End = project.EndDate ?? DateTime.MaxValue
                        };
                    })
                    .Where(p => p != null) 
                    .SelectMany(p => new[]
                    {
                        new { Time = p!.Start, IsStart = true },
                        new { Time = p!.End,   IsStart = false }
                    })
                    .OrderBy(e => e.Time)
                    .ThenBy(e => !e.IsStart)
                    .ToList();

                int active = 0;
                int maxActive = 0;

                foreach (var ev in events)
                {
                    if (ev.IsStart)
                        active++;
                    else
                        active--;

                    maxActive = Math.Max(maxActive, active);
                }

                return maxActive > 3;
            })
            .Select(g => employeesById.GetValueOrDefault(g.Key)) 
            .OfType<Employee>() 
            .ToList();

        // Q97. Get projects where all employees have more than 5 years' experience
        var projectsWithExperiencedTeams = EmployeeProjectList
            .GroupBy(ep => ep.ProjectId)
            .Where(g => g.All(ep => employeesById.TryGetValue(ep.EmployeeId, out var employee) &&
            employee.YearsOfExperience > 5))
            .Select(g => projectsById.GetValueOrDefault(g.Key))
            .OfType<Project>();

        // Q98. Find projects whose budgets exceed the average budget for their category
        var projectsAboveCategoryAverage = ProjectList
            .GroupBy(p => p.Category)
            .SelectMany(g =>
            {
                var averageBudget = g.Average(p => p.Budget);
                return g.Where(p => p.Budget > averageBudget).ToList();
            })
            .Select(p => projectsById.GetValueOrDefault(p.Id))
            .OfType<Project>()
            .ToList();

        //  Q99. Find all categories with at least one project completed in under 10 days
        var fastCompletedCategories = ProjectList
            .Where(p => p.IsCompleted &&
                        p.CompletionPercentage == 100.0 &&
                        p.EndDate.HasValue &&
                        (p.EndDate.Value - p.StartDate).TotalDays < 10)
            .Select(p => p.Category)
            .Distinct()
            .ToList();

        //  Q100. Return employees who have worked on both active and completed projects
        var employeesWorkedOnBoth = EmployeeProjectList
            .GroupBy(ep => ep.EmployeeId)
            .Where(g => 
            {
                bool hasActive = g.Any(ep => ep.IsActive);
                bool hasCompleted = g.Any(ep => projectsById.TryGetValue(ep.ProjectId, out var p) && p.IsCompleted && p.CompletionPercentage == 100.0);
                return hasActive && hasCompleted;
            })
            .Select(g => employeesById.GetValueOrDefault(g.Key))
            .OfType<Employee>() 
            .ToList();
        #endregion
    }
}
