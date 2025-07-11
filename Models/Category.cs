using System;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
}
