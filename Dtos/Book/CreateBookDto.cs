using System;

public class CreateBookDto
{
    public string Title { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
    public int PageCount { get; set; }
    public int CopiesAvailable { get; set; }
}
