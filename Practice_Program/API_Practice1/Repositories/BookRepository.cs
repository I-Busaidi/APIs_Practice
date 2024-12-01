using API_Practice1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practice1.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b => b.Borrows).FirstOrDefault(b => b.BookId == id);
        }

        public Book GetByName(string name)
        {
            return _context.Books.Include(b => b.Borrows).FirstOrDefault(b => b.BookName == name);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(int id, Book newBook)
        {
            var currentBook = GetById(id);
            if (currentBook != null)
            {
                currentBook.BookName = newBook.BookName;
                currentBook.AuthorName = newBook.AuthorName;
                currentBook.BorrowPeriod = newBook.BorrowPeriod;
                currentBook.TotalCopies = newBook.TotalCopies;
                currentBook.BorrowedCopies = newBook.BorrowedCopies;
                currentBook.CatId = newBook.CatId;
                currentBook.CopyPrice = newBook.CopyPrice;

                _context.Books.Update(currentBook);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
