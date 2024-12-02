using API_Practice1.Models;

namespace API_Practice1.Repositories
{
    public interface IBookRepository
    {
        string Add(Book book);
        void Delete(int id);
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Update(int id, Book newBook);
    }
}