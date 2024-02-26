using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public class AdminRepository: IAdmin
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void AddAdmin(Admin admin)
        {
            _applicationDbContext.Admins.Add(admin);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteAdmin(Admin admin)
        {
            _applicationDbContext.Update(admin);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _applicationDbContext.Admins.OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToList();
        }

        public Admin GetAdminByEmail(string adminEmail)
        {
            return _applicationDbContext.Admins.FirstOrDefault(a => a.Email == adminEmail);
        }

        public Admin GetAdminById(int adminId)
        {
            return _applicationDbContext.Admins.FirstOrDefault(a => a.AdminId == adminId);
        }

        public void UpdateAdmin(Admin admin)
        {
            _applicationDbContext.Update(admin);
            _applicationDbContext.SaveChanges();
        }
    }
}
