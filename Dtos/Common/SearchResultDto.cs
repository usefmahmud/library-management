using System;

public class SearchResultDto<T>
{
    public List<T> Results { get; set; } = new List<T>();
    public int TotalCount { get; set; }
    public string Query { get; set; } = string.Empty;
    public TimeSpan SearchTime { get; set; }
}
