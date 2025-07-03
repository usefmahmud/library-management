using System;

public class CreateLoanDto
{
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public DateTime? LoanDate { get; set; } // Optional, defaults to now
}
