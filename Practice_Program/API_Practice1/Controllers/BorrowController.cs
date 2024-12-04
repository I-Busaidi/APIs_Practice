using API_Practice1.Models;
using API_Practice1.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowController (IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpGet("GetAllBorrows")]
        public IActionResult GetAllBorrows()
        {
            try
            {
                var borrows = _borrowService.GetAllBorrows();
                return Ok(borrows);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBorrowById/{id}")]
        public IActionResult GetBorrowById(int id)
        {
            try
            {
                var borrow = _borrowService.GetBorrowById(id);
                return Ok(borrow);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{userId},{bookId}/BorrowBook")]
        public IActionResult AddBorrow(int userId, int bookId)
        {
            try
            {
                _borrowService.AddBorrow(userId, bookId);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{bookId}, {rating}/ReturnBook")]
        public IActionResult ReturnBook(int borrowId, int rating)
        {
            try
            {
                _borrowService.ReturnBorrowedBook(borrowId, rating);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteBorrow(int id)
        {
            try
            {
                _borrowService.RemoveBorrow(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
