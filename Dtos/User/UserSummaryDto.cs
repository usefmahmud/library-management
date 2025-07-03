using System;

public class UserSummaryDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int ActiveLoansCount { get; set; }
    public bool HasOverdueBooks { get; set; }
}
