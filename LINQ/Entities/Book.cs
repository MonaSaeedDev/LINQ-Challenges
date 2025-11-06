using LINQ.Enums;

namespace LINQ.Entities;

// Entity 3: Book
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public BookGenre Genre { get; set; }
    public decimal Price { get; set; }
    public int Pages { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime PublicationDate { get; set; }
    public double Rating { get; set; } // 0.0 - 5.0
    public int CopiesInStock { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, " +
               $"Title: {Title}, " +
               $"Author: {Author}, " +
               $"Genre: {Genre}, " +
               $"Price: {Price:C}, " +
               $"Pages: {Pages}, " +
               $"Available: {IsAvailable}, " +
               $"Published: {PublicationDate:yyyy-MM-dd}, " +
               $"Rating: {Rating}/5, " +
               $"Copies In Stock: {CopiesInStock}";
    }

}