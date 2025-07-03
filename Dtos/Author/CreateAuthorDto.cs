using System;

public class CreateAuthorDto
{
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
}
