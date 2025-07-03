using System;

public class ActiveLoanDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public DateTime LoanDate { get; set; }
    public DateTime DueDate => LoanDate.AddDays(14);
    public int DaysOverdue => Math.Max(0, (DateTime.UtcNow - DueDate).Days);
    public bool IsOverdue => DateTime.UtcNow > DueDate;
}
