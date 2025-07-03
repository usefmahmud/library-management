using System;

public class BookSummaryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public AuthorSummaryDto Author { get; set; } = new AuthorSummaryDto();
    public List<CategorySummaryDto> Categories { get; set; } = new List<CategorySummaryDto>();
    public int PageCount { get; set; }
    public bool IsAvailable { get; set; }
}
