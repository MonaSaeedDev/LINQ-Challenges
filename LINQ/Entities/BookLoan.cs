namespace LINQ.Entities;

// Relationship Entity 2: BookLoan (Relationship between Employee and Book)
public class BookLoan
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public decimal? LateFee { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, " +
               $"Employee ID: {EmployeeId}, " +
               $"Book ID: {BookId}, " +
               $"Loan Date: {LoanDate:yyyy-MM-dd}, " +
               $"Due Date: {DueDate:yyyy-MM-dd}, " +
               $"Return Date: {(ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "Not Returned")}, " +
               $"Returned: {IsReturned}, " +
               $"Late Fee: {(LateFee.HasValue ? LateFee.Value.ToString("C") : "None")}";
    }

}