using System;
using Microsoft.EntityFrameworkCore;

public class BookService : IBookService
{
    private readonly LibraryContext _context;

    public BookService(LibraryContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<BookDto>> GetAllBooksAsync(int pageNumber, int pageSize)
    {
        var totalBooks = await _context.Books.CountAsync();
        var books = await _context.Books
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                AuthorName = b.Author.Name,
                CategoryNames = b.Categories.Select(c => c.Name).ToList()
            })
            .ToListAsync();

        return new PaginatedResult<BookDto>
        {
            Items = books,
            TotalCount = totalBooks,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<BookDetailDto> GetBookByIdAsync(Guid id)
    {
        var book = await _context.Books
            .Include(b => b.Author)
            .Include(b => b.Categories)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            throw new KeyNotFoundException("Book not found.");
        }

        return new BookDetailDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = new AuthorSummaryDto
            {
                Id = book.Author.Id,
                Name = book.Author.Name
            },
            Categories = book.Categories.Select(c => new CategorySummaryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList(),
            CopiesAvailable = book.CopiesAvailable
        };
    }

    public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto)
    {
        var author = await _context.Authors.FindAsync(createBookDto.AuthorId);
        if (author == null)
        {
            throw new ArgumentException("Author not found.");
        }

        var categoryCount = await _context.Categories
            .Where(c => createBookDto.CategoryIds.Contains(c.Id))
            .CountAsync();

        if (categoryCount != createBookDto.CategoryIds.Count)
        {
            throw new ArgumentException("One or more categories not found.");
        }

        var book = new Book
        {
            Title = createBookDto.Title,
            Author = author,
            Categories = await _context.Categories
                .Where(c => createBookDto.CategoryIds.Contains(c.Id))
                .ToListAsync()
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            AuthorName = book.Author.Name,
            CategoryNames = book.Categories.Select(c => c.Name).ToList()
        };
    }
}
