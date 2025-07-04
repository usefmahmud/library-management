using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<AuthorSummaryDto>>> GetAllAuthors(int pageNumber = 1, int pageSize = 10)
        {
            var authors = await _authorService.GetAllAuthorsAsync(pageNumber, pageSize);
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailDto>> GetAuthorById(Guid id)
        {
            try
            {
                var author = await _authorService.GetAuthorByIdAsync(id);
                return Ok(author);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto createAuthorDto)
        {
            try
            {
                if (createAuthorDto == null)
                {
                    return BadRequest(new { error = "Author data is required." });
                }

                var createdAuthor = await _authorService.CreateAuthorAsync(createAuthorDto);
                return CreatedAtAction(nameof(GetAllAuthors), new { id = createdAuthor.Id }, createdAuthor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An error occurred while creating the author." });
            }
        }
    }
}
