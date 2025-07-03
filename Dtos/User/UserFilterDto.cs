using System;

public class UserFilterDto : PaginationParams
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool? HasActiveLoans { get; set; }
    public bool? HasOverdueBooks { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }
}
