using System;

public interface IBookService
{
    Task<PaginatedResult<BookDto>> GetAllBooksAsync(int pageNumber, int pageSize);
    Task<BookDetailDto> GetBookByIdAsync(Guid id);
    Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
}
