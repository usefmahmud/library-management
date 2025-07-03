using System;

public class LibraryStatsDto
{
    public int TotalBooks { get; set; }
    public int TotalAuthors { get; set; }
    public int TotalUsers { get; set; }
    public int TotalCategories { get; set; }
    public int ActiveLoans { get; set; }
    public int OverdueLoans { get; set; }
    public int BooksAvailable { get; set; }
    public int BooksLoaned { get; set; }
    public List<CategoryStatsDto> PopularCategories { get; set; } = new List<CategoryStatsDto>();
    public List<BookStatsDto> MostBorrowedBooks { get; set; } = new List<BookStatsDto>();
}

public class CategoryStatsDto
{
    public string CategoryName { get; set; } = string.Empty;
    public int BookCount { get; set; }
    public int LoanCount { get; set; }
}

public class BookStatsDto
{
    public string BookTitle { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public int LoanCount { get; set; }
}
