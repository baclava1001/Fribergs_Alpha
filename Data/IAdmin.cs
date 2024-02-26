using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface IAdmin
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminById(int adminId);
        Admin GetAdminByEmail(string adminEmail);
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
    }
}
