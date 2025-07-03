using System;

public class UserStatsDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public int TotalBooksRead { get; set; }
    public int CurrentActiveLoans { get; set; }
    public int OverdueBooks { get; set; }
    public DateTime LastLoanDate { get; set; }
    public List<string> FavoriteCategories { get; set; } = new List<string>();
    public List<BookStatsDto> RecentlyRead { get; set; } = new List<BookStatsDto>();
}
