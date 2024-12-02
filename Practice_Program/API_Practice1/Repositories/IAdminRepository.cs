using API_Practice1.Models;

namespace API_Practice1.Repositories
{
    public interface IAdminRepository
    {
        int Add(Admin admin);
        void Delete(int id);
        IEnumerable<Admin> GetAll();
        Admin GetById(int id);
        void Update(int id, Admin newAdmin);
    }
}