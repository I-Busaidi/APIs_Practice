using API_Practice1.Repositories;
using API_Practice1.Models;
using System.Text.RegularExpressions;

namespace API_Practice1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAll().OrderBy(u=>u.FName).ToList();
            if (users == null || users.Count == 0)
            {
                throw new InvalidOperationException("No users found.");
            }
            return users;
        }

        public List<User> GetUsersByName(string name)
        {
            var users = _userRepository.GetAll()
                .Where(u => u.FName.ToLower().Contains(name.ToLower())
                || u.LName.ToLower().Contains(name.ToLower())
                || name.ToLower().Contains(u.FName.ToLower())
                || name.ToLower().Contains(u.LName.ToLower()))
                .OrderBy(u => u.FName)
                .ToList();
            if (users == null || users.Count == 0)
            {
                throw new InvalidOperationException("User not found.");
            }
            return users;
        }

        public User GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            return user;
        }

        public void AddUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FName))
            {
                throw new ArgumentException("User first name is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("User email is required.");
            }

            if (string.IsNullOrWhiteSpace(user.Passcode))
            {
                throw new ArgumentException("User password is required.");
            }

            if (!Regex.IsMatch(user.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                throw new ArgumentException("Email does not match the required format.");
            }

            if (!Regex.IsMatch(user.Passcode, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$"))
            {
                throw new ArgumentException("Passcode does not match the required pattern.");
            }

            _userRepository.Add(user);
        }

        public void RemoveUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            _userRepository.Delete(id);
        }

        public void UpdateUser(int id, User newUser)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            newUser.UserId = existingUser.UserId;
            _userRepository.Update(id, newUser);
        }
    }
}
