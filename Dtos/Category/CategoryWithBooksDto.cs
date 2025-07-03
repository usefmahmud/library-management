using System;

public class CategoryWithBooksDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<BookSummaryDto> Books { get; set; } = new List<BookSummaryDto>();
    public int TotalBooks => Books.Count;
}
