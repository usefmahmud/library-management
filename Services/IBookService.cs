using System;

public interface IBookService
{
    Task<PaginatedResult<BookSummaryDto>> GetAllBooksAsync(int pageNumber, int pageSize);
    Task<BookDetailDto> GetBookByIdAsync(Guid id);
    Task<BookDto> CreateBookAsync(CreateBookDto createBookDto);
}
