using LINQ.Enums;

namespace LINQ.Entities;

// Relationship Entity 1: EmployeeProject (Many-to-Many between Employee and Project)
public class EmployeeProject
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
    public ProjectRole Role { get; set; }
    public int HoursAllocated { get; set; }
    public DateTime AssignedDate { get; set; }
    public bool IsActive { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, " +
               $"Employee ID: {EmployeeId}, " +
               $"Project ID: {ProjectId}, " +
               $"Role: {Role}, " +
               $"Hours Allocated: {HoursAllocated}, " +
               $"Assigned Date: {AssignedDate:yyyy-MM-dd}, " +
               $"Active: {IsActive}";
    }

}