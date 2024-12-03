using API_Practice1.Models;
using API_Practice1.Repositories;

namespace API_Practice1.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryService _categoryService;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            var books = _bookRepository.GetAll().ToList();
            if (books == null || books.Count == 0)
            {
                throw new InvalidOperationException("No books found.");
            }
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }
            return book;
        }

        public List<Book> GetBookByName(string name)
        {
            var books = _bookRepository.GetAll().Where(b => b.BookName == name).ToList();
            if (books == null || books.Count == 0)
            {
                throw new ArgumentException("Book not found.");
            }
            return books;
        }

        public string AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.BookName))
            {
                throw new ArgumentException("Book name is required.");
            }

            if (string.IsNullOrWhiteSpace(book.AuthorName))
            {
                throw new ArgumentException("Author name is required.");
            }

            if (book.BorrowPeriod <= 0)
            {
                throw new ArgumentException("Allowed borrowing period must be greater than 0");
            }

            if (book.CopyPrice <= 0)
            {
                throw new ArgumentException("Copy price must be greater than 0");
            }

            if (book.CatId == null || book.CatId <= 0)
            {
                throw new ArgumentException("Category ID must be entered.");
            }
            _categoryService.IncrementCategoryBookNumber(book.CatId);
            return _bookRepository.Add(book) + " Added Successfully.";
        }

        public void UpdateBook(int id, Book book)
        {
            var existingBook = _bookRepository.GetById(id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            if (string.IsNullOrWhiteSpace(book.BookName))
            {
                throw new ArgumentException("Book name is required.");
            }

            if (string.IsNullOrWhiteSpace(book.AuthorName))
            {
                throw new ArgumentException("Author name is required.");
            }

            if (book.BorrowPeriod <= 0)
            {
                throw new ArgumentException("Allowed borrowing period must be greater than 0");
            }

            if (book.CopyPrice <= 0)
            {
                throw new ArgumentException("Copy price must be greater than 0");
            }

            if (book.CatId == null || book.CatId <= 0)
            {
                throw new ArgumentException("Category ID must be entered.");
            }

            book.BookId = existingBook.BookId;
            _bookRepository.Update(book.BookId, book);
        }

        public void RemoveBook(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            if (book.BorrowedCopies > 0)
            {
                throw new ArgumentException("Book is currently borrowed.");
            }
            _categoryService.DecrementCategoryBookNumber(book.CatId);
            _bookRepository.Delete(book.BookId);
        }

        public void BorrowBook(int id)
        {
            var book = GetBookById(id);

            if (book.TotalCopies > book.BorrowedCopies)
            {
                book.BorrowedCopies++;
            }

            _bookRepository.Update(id, book);
        }

        public void ReturnBook(int id)
        {
            var book = GetBookById(id);

            if (book.BorrowedCopies > 0)
            {
                book.BorrowedCopies--;
            }

            _bookRepository.Update(id, book);
        }
    }
}
