using API_Practice1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practice1.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly ApplicationDbContext _context;

        public BorrowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Borrow> GetAll()
        {
            return _context.Borrows.Include(u => u.User).Include(b => b.Book);
        }

        public Borrow GetById(int id)
        {
            return _context.Borrows.Include(u => u.User).Include(b => b.Book).FirstOrDefault(br => br.BorrowId == id);
        }

        public void Add(Borrow borrow)
        {
            _context.Borrows.Add(borrow);
            _context.SaveChanges();
        }

        public void Update(int id, Borrow newBorrow)
        {
            var currentBorrow = GetById(id);
            if (currentBorrow != null)
            {
                currentBorrow.BorrowDate = newBorrow.BorrowDate;
                currentBorrow.ReturnDate = newBorrow.ReturnDate;
                currentBorrow.ActualReturnDate = newBorrow.ActualReturnDate;
                currentBorrow.IsReturned = newBorrow.IsReturned;
                currentBorrow.Rating = newBorrow.Rating;

                _context.Borrows.Update(currentBorrow);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var borrow = GetById(id);
            if (borrow != null)
            {
                _context.Borrows.Remove(borrow);
                _context.SaveChanges();
            }
        }
    }
}
