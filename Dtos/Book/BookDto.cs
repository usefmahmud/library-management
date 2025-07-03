using System;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int CopiesAvailable { get; set; }
    public int PageCount { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public List<string> CategoryNames { get; set; } = new List<string>();
    public bool IsAvailable => CopiesAvailable > 0;
}
