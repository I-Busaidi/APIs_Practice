using API_Practice1.Models;

namespace API_Practice1.Services
{
    public interface IAdminService
    {
        int AddAdmin(Admin admin);
        void ChangeAdminSupervisor(int id, int sId);
        Admin GetAdminById(int id);
        List<Admin> GetAdminByName(string name);
        List<Admin> GetAllAdmins();
        void UpdateAdminEmail(int id, string email);
        void UpdateAdminInfo(int id, Admin admin);
        void UpdateAdminName(int id, string fname, string? lname);
        void UpdateAdminPasscode(int id, string passcode);
        void DeleteAdmin(int id);
    }
}