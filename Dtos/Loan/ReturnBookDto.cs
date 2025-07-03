using System;

public class ReturnBookDto
{
    public DateTime? ReturnDate { get; set; } // Optional, defaults to now
    public string? Notes { get; set; } // Optional return notes
}
