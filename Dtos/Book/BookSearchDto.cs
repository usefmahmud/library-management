using System;

public class BookSearchDto
{
    public string Query { get; set; } = string.Empty;
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
    public bool? IsAvailable { get; set; }
    public string? SortBy { get; set; } // "title", "author", "pageCount"
    public bool IsDescending { get; set; } = false;
}
