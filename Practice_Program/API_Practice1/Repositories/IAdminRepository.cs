using API_Practice1.Models;

namespace API_Practice1.Repositories
{
    public interface IAdminRepository
    {
        void Add(Admin admin);
        void Delete(int id);
        IEnumerable<Admin> GetAll();
        Admin GetById(int id);
        IEnumerable<Admin> GetByName(string name);
        void Update(int id, Admin newAdmin);
    }
}