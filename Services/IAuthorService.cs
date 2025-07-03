using System;

public interface IAuthorService
{
    public Task<PaginatedResult<AuthorSummaryDto>> GetAllAuthorsAsync(int pageNumber, int pageSize);
    public Task<AuthorDetailDto> GetAuthorByIdAsync(Guid id);
    public Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
}
