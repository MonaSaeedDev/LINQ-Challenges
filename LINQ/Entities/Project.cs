using LINQ.Enums;

namespace LINQ.Entities;

// Entity 2: Project
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ProjectCategory Category { get; set; }
    public decimal Budget { get; set; }
    public int TeamSize { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int Priority { get; set; } // 1-5, where 5 is highest
    public double CompletionPercentage { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, " +
               $"Name: {Name}, " +
               $"Category: {Category}, " +
               $"Budget: {Budget:C}, " +
               $"Team Size: {TeamSize}, " +
               $"Completed: {IsCompleted}, " +
               $"Start Date: {StartDate:yyyy-MM-dd}, " +
               $"End Date: {(EndDate.HasValue ? EndDate.Value.ToString("yyyy-MM-dd") : "Ongoing")}, " +
               $"Priority: {Priority}, " +
               $"Completion: {CompletionPercentage}%";
    }

}