using API_Practice1.Models;

namespace API_Practice1.Services
{
    public interface IBookService
    {
        string AddBook(Book book);
        void BorrowBook(int id);
        void ReturnBook(int id);
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        List<Book> GetBookByName(string name);
        void RemoveBook(int id);
        void UpdateBook(int id, Book book);
    }
}