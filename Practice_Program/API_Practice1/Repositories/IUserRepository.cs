using API_Practice1.Models;

namespace API_Practice1.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(int id);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Update(int id, User newUser);
    }
}