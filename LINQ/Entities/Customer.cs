//using ConsoleApp4;

namespace LINQ.Entities;

public class Customer : IComparable<Customer>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public Order[] Orders { get; set; } = null!; // order,order,order,order

    public Customer(string id, string name)
    {
        Id = id;
        Name = name;
        Orders = new Order[10];
    }

    public Customer() { }

    public override string ToString()
        => $"{Id}, {Name}, {Address}, {City}, {Region}, {PostalCode}, {Country}";

    public int CompareTo(Customer? other)
    {
        if (other is null)
            return 1;

        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}
