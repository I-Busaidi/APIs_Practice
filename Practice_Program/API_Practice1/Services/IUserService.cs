using API_Practice1.Models;

namespace API_Practice1.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        List<User> GetUsersByName(string name);
        void RemoveUser(int id);
        void UpdateUser(int id, User newUser);
    }
}