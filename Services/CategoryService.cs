using System;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    private readonly LibraryContext _context;

    public CategoryService(LibraryContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<CategorySummaryDto>> GetAllCategoriesAsync(int pageNumber, int pageSize)
    {
        var categories = await _context.Categories
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(c => new CategorySummaryDto
            {
                Id = c.Id,
                Name = c.Name,
                TotalBooks = c.Books.Count
            })
            .ToListAsync();

        var totalCount = await _context.Categories.CountAsync();

        return new PaginatedResult<CategorySummaryDto>
        {
            Items = categories,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<CategoryWithBooksDto> GetCategoryByIdAsync(Guid id)
    {
        var category = await _context.Categories
            .Include(c => c.Books)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            throw new KeyNotFoundException("Category not found");
        }

        return new CategoryWithBooksDto
        {
            Id = category.Id,
            Name = category.Name,
            Books = category.Books.Select(b => new BookSummaryDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = new AuthorSummaryDto
                {
                    Id = b.Author.Id,
                    Name = b.Author.Name
                },
            }).ToList()
        };
    }

    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var category = new Category
        {
            Name = createCategoryDto.Name
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
