using API_Practice1.Models;

namespace API_Practice1.Repositories
{
    public interface IBorrowRepository
    {
        void Add(Borrow borrow);
        void Delete(int id);
        IEnumerable<Borrow> GetAll();
        Borrow GetById(int id);
        void Update(int id, Borrow newBorrow);
    }
}