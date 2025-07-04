using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<BookDto>>> GetAllBooks(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _bookService.GetAllBooksAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                return Ok(book);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the book.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookDto createBookDto)
        {
            if (createBookDto == null)
            {
                return BadRequest("Book data is required.");
            }

            try
            {
                var createdBook = await _bookService.CreateBookAsync(createBookDto);
                return CreatedAtAction(nameof(GetAllBooks), new { id = createdBook.Id }, createdBook);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the book.");
            }
        }
    }
}
