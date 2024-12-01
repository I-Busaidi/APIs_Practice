using API_Practice1.Models;

namespace API_Practice1.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }

        public Admin GetById(int id)
        {
            return _context.Admins.FirstOrDefault(a => a.AdminId == id);
        }

        public IEnumerable<Admin> GetByName(string name)
        {
            return _context.Admins.Where(a => a.AdminFname.Contains(name) || a.AdminLname.Contains(name) || name.Contains(a.AdminFname) || name.Contains(a.AdminLname));
        }

        public void Add(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var admin = GetById(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
        }

        public void Update(int id, Admin newAdmin)
        {
            var currentAdmin = GetById(id);
            if (currentAdmin != null)
            {
                currentAdmin.AdminFname = newAdmin.AdminFname;
                currentAdmin.AdminLname = newAdmin.AdminLname;
                currentAdmin.AdminEmail = newAdmin.AdminEmail;
                currentAdmin.AdminPasscode = newAdmin.AdminPasscode;
                currentAdmin.MasterAdminId = newAdmin.MasterAdminId;
                _context.Admins.Update(currentAdmin);
                _context.SaveChanges();
            }
        }
    }
}
