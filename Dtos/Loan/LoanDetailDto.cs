using System;

public class LoanDetailDto
{
    public Guid Id { get; set; }
    public BookSummaryDto Book { get; set; } = new BookSummaryDto();
    public UserDto User { get; set; } = new UserDto();
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned => ReturnDate.HasValue;
    public DateTime DueDate => LoanDate.AddDays(14);
    public int DaysOverdue => IsReturned ? 0 : Math.Max(0, (DateTime.UtcNow - DueDate).Days);
    public bool IsOverdue => !IsReturned && DateTime.UtcNow > DueDate;
}
