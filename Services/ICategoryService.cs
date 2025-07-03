using System;

public interface ICategoryService
{
    Task<PaginatedResult<CategorySummaryDto>> GetAllCategoriesAsync(int pageNumber, int pageSize);
    Task<CategoryWithBooksDto> GetCategoryByIdAsync(Guid id);
    Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
}
