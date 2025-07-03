using System;

public class Loan
{
    public Guid Id { get; set; }
    public required Book Book { get; set; }
    public required User User { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned => ReturnDate.HasValue;

    public Loan()
    {
        LoanDate = DateTime.UtcNow;
    }
}
