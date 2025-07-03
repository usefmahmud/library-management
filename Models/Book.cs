using System;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public int CopiesAvailable { get; set; }
    public int PageCount { get; set; }
    public required Author Author { get; set; }
    public required List<Category> Categories { get; set; } = new List<Category>();
}
