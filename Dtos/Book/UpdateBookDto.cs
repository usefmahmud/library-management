using System;

public class UpdateBookDto
{
    public string Title { get; set; } = string.Empty;
    public int CopiesAvailable { get; set; }
    public int PageCount { get; set; }
    public Guid AuthorId { get; set; }
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
}
