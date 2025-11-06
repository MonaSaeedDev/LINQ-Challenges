using LINQ.Entities;
using System.Collections.Generic;
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
        var categorizedAverageSalary = ListGenerator.EmployeeList.GroupBy(e => e.Department).Select(g => new
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

    }
}