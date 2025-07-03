using System;

public class UserProfileDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<LoanDto> ActiveLoans { get; set; } = new List<LoanDto>();
    public List<LoanDto> LoanHistory { get; set; } = new List<LoanDto>();
    public int TotalBooksRead { get; set; }
    public int OverdueBooks { get; set; }
    public DateTime? LastLoanDate { get; set; }
}
