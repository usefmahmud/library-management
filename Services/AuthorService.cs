using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

public class AuthorService : IAuthorService
{
    private readonly LibraryContext _context;
    public AuthorService(LibraryContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<AuthorSummaryDto>> GetAllAuthorsAsync(int pageNumber = 1, int pageSize = 10)
    {
        var totalAuthors = await _context.Authors.CountAsync();
        var authors = await _context.Authors
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(a => new AuthorSummaryDto
            {
                Id = a.Id,
                Name = a.Name,
                Bio = a.Bio,
                BookCount = a.Books.Count()
            }).ToListAsync();

        return new PaginatedResult<AuthorSummaryDto>
        {
            Items = authors,
            TotalCount = totalAuthors,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<AuthorDetailDto> GetAuthorByIdAsync(Guid id)
    {
        var author = await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (author == null)
        {
            throw new KeyNotFoundException("Author not found.");
        }

        return new AuthorDetailDto
        {
            Id = author.Id,
            Name = author.Name,
            Bio = author.Bio,
            Books = author.Books.Select(b => new BookSummaryDto
            {
                Id = b.Id,
                Title = b.Title
            }).ToList()
        };
    }

    public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
    {
        var author = new Author
        {
            Id = Guid.NewGuid(),
            Name = createAuthorDto.Name,
            Bio = createAuthorDto.Bio,
            Books = new List<Book>()
        };

        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name
        };
    }
}
