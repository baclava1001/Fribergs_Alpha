using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetAllCustomers();
        IEnumerable<User> GetAllAdmins();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

    }
}
