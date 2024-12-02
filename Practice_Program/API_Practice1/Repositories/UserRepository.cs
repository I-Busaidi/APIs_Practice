using API_Practice1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Practice1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(u => u.Borrows);
        }

        public User GetById(int id)
        {
            return _context.Users.Include(u => u.Borrows).FirstOrDefault(u => u.UserId == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, User newUser)
        {
            var currentUser = GetById(id);
            if (currentUser != null)
            {
                currentUser.FName = newUser.FName;
                currentUser.LName = newUser.LName;
                currentUser.Gender = newUser.Gender;
                currentUser.Email = newUser.Email;
                currentUser.Passcode = newUser.Passcode;

                _context.Users.Update(currentUser);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
