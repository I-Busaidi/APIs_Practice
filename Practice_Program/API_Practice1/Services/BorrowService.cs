using API_Practice1.Models;
using API_Practice1.Repositories;
using Microsoft.AspNetCore.Components.Forms;

namespace API_Practice1.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public BorrowService(IBorrowRepository borrowRepository, IBookService bookService, IUserService userService)
        {
            _borrowRepository = borrowRepository;
            _bookService = bookService;
            _userService = userService;
        }

        public List<Borrow> GetAllBorrows()
        {
            var borrows = _borrowRepository.GetAll().ToList();
            if (borrows == null || borrows.Count == 0)
            {
                throw new InvalidOperationException("No borrows found.");
            }
            return borrows;
        }

        public Borrow GetBorrowById(int id)
        {
            var borrow = _borrowRepository.GetById(id);
            if (borrow == null)
            {
                throw new KeyNotFoundException("Borrwing with this ID not found.");
            }
            return borrow;
        }

        public void AddBorrow(int uId, int bId)
        {
            var book = _bookService.GetBookById(bId);
            if (book.BorrowedCopies >= book.TotalCopies)
            {
                throw new InvalidOperationException("Book is currently unavailable.");
            }
            var user = _userService.GetUserById(uId);
            foreach (var borrow in user.Borrows)
            {
                if (borrow.BookId == book.BookId && !borrow.IsReturned)
                {
                    throw new InvalidOperationException("User is already borrowing this book.");
                }
            }
            var newBorrow = new Borrow
            {
                BookId = book.BookId,
                UserId = user.UserId,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(book.BorrowPeriod)
            };
            _bookService.BorrowBook(book.BookId);
            _borrowRepository.Add(newBorrow);
        }

        public void ReturnBorrowedBook(int id, int rating)
        {
            var borrow = _borrowRepository.GetById(id);
            if (borrow == null)
            {
                throw new KeyNotFoundException("The borrowing with this ID not found.");
            }

            borrow.ActualReturnDate = DateTime.Now;
            borrow.IsReturned = true;
            borrow.Rating = rating;

            _bookService.ReturnBook(borrow.BookId);
            _borrowRepository.Update(id, borrow);
        }

        public void RemoveBorrow(int id)
        {
            var borrow = _borrowRepository.GetById(id);
            if (borrow == null)
            {
                throw new KeyNotFoundException("The borrowing with this ID is not found.");
            }
            if (!borrow.IsReturned)
            {
                throw new InvalidOperationException("The borrowed book is not returned yet.");
            }
            _borrowRepository.Delete(id);
        }

    }
}
