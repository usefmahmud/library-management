using System;

public class LoanDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned => ReturnDate.HasValue;
    public int DaysOverdue => IsReturned ? 0 : Math.Max(0, (DateTime.UtcNow - LoanDate.AddDays(14)).Days);
}
