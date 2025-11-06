namespace LINQ.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Total { get; set; }

    public List<Product> Products = [];
    public Order(int id, DateTime date, decimal total)
    {
        Id = id;
        Date = date;
        Total = total;
    }

    public Order() { }

    public override string ToString()
        => $"Order Id: {Id}, Date: {Date.ToShortDateString()}, Total: {Total}";
}
