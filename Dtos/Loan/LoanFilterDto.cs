using System;

public class LoanFilterDto : PaginationParams
{
    public Guid? UserId { get; set; }
    public Guid? BookId { get; set; }
    public bool? IsReturned { get; set; }
    public DateTime? LoanDateFrom { get; set; }
    public DateTime? LoanDateTo { get; set; }
    public bool? IsOverdue { get; set; }
}
