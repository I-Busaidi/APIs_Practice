using API_Practice1.Models;
using API_Practice1.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = _bookService.GetBookById(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBookByName/{name}")]
        public IActionResult GetBookByName(string name)
        {
            try
            {
                var books = _bookService.GetBookByName(name);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook(string bName, string aName, int borrowPeriod, int totalCopies, int categoryId, decimal copyPrice)
        {
            try
            {
                string newBookName = _bookService.AddBook(new Book
                {
                    BookName = bName,
                    AuthorName = aName,
                    BorrowPeriod = borrowPeriod,
                    TotalCopies = totalCopies,
                    CatId = categoryId,
                    CopyPrice = copyPrice
                });
                return Created(string.Empty, newBookName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, string bName, string aName, int borrowPeriod, int totalCopies, decimal copyPrice)
        {
            try
            {
                _bookService.UpdateBook(id, new Book
                {
                    BookName = bName,
                    AuthorName = aName,
                    BorrowPeriod = borrowPeriod,
                    TotalCopies = totalCopies,
                    CopyPrice = copyPrice
                });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.RemoveBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
