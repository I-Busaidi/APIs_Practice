using API_Practice1.Models;
using API_Practice1.Repositories;

namespace API_Practice1.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService (IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _adminRepository.GetAll();
        }

        public Admin GetAdminById(int id)
        {
            return _adminRepository.GetById(id);
        }

        public IEnumerable<Admin> GetAdminsByName(string name)
        {
            return _adminRepository.GetByName(name);
        }


    }
}
