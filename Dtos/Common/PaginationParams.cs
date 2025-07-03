using System;

public class PaginationParams
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    
    private const int MaxSize = 100;
    public int ValidSize => Size > MaxSize ? MaxSize : Size;
    public int ValidPage => Page < 1 ? 1 : Page;
}
