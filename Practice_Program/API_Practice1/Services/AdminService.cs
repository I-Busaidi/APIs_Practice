using API_Practice1.Models;
using API_Practice1.Repositories;
using System;
using System.Text.RegularExpressions;

namespace API_Practice1.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public List<Admin> GetAllAdmins()
        {
            var admins = _adminRepository.GetAll().ToList();
            if (admins == null || admins.Count == 0)
            {
                throw new InvalidOperationException("No admins found.");
            }
            return admins;
        }

        public Admin GetAdminById(int id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }
            return admin;
        }

        public List<Admin> GetAdminByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Search term entered is null.");
            }
            var admins = _adminRepository.GetAll()
                .Where(a => a.AdminFname.Contains(name)
                || a.AdminFname.Contains(name)
                || name.Contains(a.AdminFname)
                || name.Contains(a.AdminLname))
                .ToList();

            if (admins == null || admins.Count == 0)
            {
                throw new Exception("No admin with matching name found.");
            }
            return admins;
        }

        public int AddAdmin(Admin admin)
        {
            if (string.IsNullOrWhiteSpace(admin.AdminFname))
            {
                throw new ArgumentException("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(admin.AdminEmail))
            {
                throw new ArgumentException("Email is required.");
            }

            if (!Regex.IsMatch(admin.AdminEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                throw new ArgumentException("Email does not match the required format.");
            }

            if (!Regex.IsMatch(admin.AdminPasscode, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$"))
            {
                throw new ArgumentException("Passcode does not match the required pattern.");
            }

            if (string.IsNullOrWhiteSpace(admin.AdminPasscode))
            {
                throw new ArgumentException("Password is required.");
            }
            return _adminRepository.Add(admin);
        }

        public void UpdateAdminInfo(int id, Admin admin)
        {
            var existingAdmin = _adminRepository.GetById(id);
            if (existingAdmin == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }

            if (string.IsNullOrWhiteSpace(admin.AdminFname))
            {
                throw new ArgumentException("First name is required.");
            }

            if (string.IsNullOrWhiteSpace(admin.AdminEmail))
            {
                throw new ArgumentException("Email is required.");
            }

            if (!Regex.IsMatch(admin.AdminEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                throw new ArgumentException("Email does not match the required format.");
            }

            if (!Regex.IsMatch(admin.AdminPasscode, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$"))
            {
                throw new ArgumentException("Passcode does not match the required pattern.");
            }

            if (string.IsNullOrWhiteSpace(admin.AdminPasscode))
            {
                throw new ArgumentException("Password is required.");
            }
            admin.AdminId = existingAdmin.AdminId;
            _adminRepository.Update(id, admin);
        }

        public void UpdateAdminEmail(int id, string email)
        {
            var admin = _adminRepository.GetById(id);
            if (admin == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email entered is null.");
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                throw new ArgumentException("Email does not match the required format.");
            }
            admin.AdminEmail = email;
            _adminRepository.Update(id, admin);
        }

        public void UpdateAdminName(int id, string fname, string? lname)
        {
            var admin = _adminRepository.GetById(id);
            if (admin == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }

            if (string.IsNullOrWhiteSpace(fname))
            {
                throw new ArgumentException("First name is required.");
            }

            admin.AdminFname = fname;
            admin.AdminLname = lname;
            _adminRepository.Update(id, admin);
        }

        public void UpdateAdminPasscode(int id, string passcode)
        {
            var admin = _adminRepository.GetById(id);
            if (admin == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }

            if (string.IsNullOrWhiteSpace(passcode))
            {
                throw new ArgumentException("Passcode entered is null.");
            }

            if (!Regex.IsMatch(passcode, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$"))
            {
                throw new ArgumentException("Passcode does not match the required pattern.");
            }
            admin.AdminPasscode = passcode;
            _adminRepository.Update(id, admin);
        }

        public void ChangeAdminSupervisor(int id, int sId)
        {
            var admin = _adminRepository.GetById(id);
            var sAdmin = _adminRepository.GetById(sId);

            if (admin == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }

            if (sAdmin == null)
            {
                throw new KeyNotFoundException("Supervisor admin not found.");
            }

            admin.MasterAdminId = sAdmin.AdminId;
            _adminRepository.Update(id, admin);
        }
    }
}
