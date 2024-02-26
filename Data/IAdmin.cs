using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface IAdmin
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminById(int AdminId);
        Admin GetAdminByEmail(string AdminEmail);
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
    }
}
