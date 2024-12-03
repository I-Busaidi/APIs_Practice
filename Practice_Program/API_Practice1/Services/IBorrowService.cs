using API_Practice1.Models;

namespace API_Practice1.Services
{
    public interface IBorrowService
    {
        void AddBorrow(int uId, int bId);
        List<Borrow> GetAllBorrows();
        Borrow GetBorrowById(int id);
        void RemoveBorrow(int id);
        void ReturnBorrowedBook(int id, int rating);
    }
}