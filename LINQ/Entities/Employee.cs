//using LINQ;

using LINQ.Enums;

namespace LINQ.Entities;

// Entity 1: Employee
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Department Department { get; set; }
    public decimal Salary { get; set; }
    public int YearsOfExperience { get; set; }
    public bool IsRemote { get; set; }
    public DateTime HireDate { get; set; }
    public int? ManagerId { get; set; }
    public bool IsActive { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, " +
               $"Name: {Name}, " +
               $"Department: {Department.ToString() ?? "N/A"}, " +
               $"Salary: {Salary:C}, " +
               $"Experience: {YearsOfExperience} yrs, " +
               $"Remote: {IsRemote}, " +
               $"Hire Date: {HireDate:yyyy-MM-dd}, " +
               $"Manager ID: {(ManagerId.HasValue ? ManagerId.Value.ToString() : "None")}, " +
               $"Active: {IsActive}";
    }
}