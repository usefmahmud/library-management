using System;

public class AuthorDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public List<BookSummaryDto> Books { get; set; } = new List<BookSummaryDto>();
    public int TotalBooks => Books.Count;
}
