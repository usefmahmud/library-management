using System;

public class BookFilterDto : PaginationParams
{
    public string? Title { get; set; }
    public Guid? AuthorId { get; set; }
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
    public bool? IsAvailable { get; set; }
    public int? MinPageCount { get; set; }
    public int? MaxPageCount { get; set; }
}
