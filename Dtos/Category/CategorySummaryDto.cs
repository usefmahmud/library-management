using System;

public class CategorySummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TotalBooks { get; set; }
}
