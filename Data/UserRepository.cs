using Fribergs_Alpha.Models;
using Microsoft.EntityFrameworkCore;

namespace Fribergs_Alpha.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext DbContext)
        {
            _applicationDbContext = DbContext;
        }

        public void AddUser(User user)
        {
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _applicationDbContext.Users.Find(id);

            if(user != null)
            {
                _applicationDbContext.Users.Remove(user);
                _applicationDbContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _applicationDbContext.Users.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public IEnumerable<User> GetAllCustomers()
        {
            return _applicationDbContext.Users.Where(x => x.AdminRole == false).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public IEnumerable<User> GetAllAdmins()
        {
            return _applicationDbContext.Users.Where(x => x.AdminRole == true).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _applicationDbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserById(int id)
        {
            return _applicationDbContext.Users.Include(x => x.Bookings).FirstOrDefault(x => x.UserId == id);
        }

        public void UpdateUser(User user)
        {
            _applicationDbContext.Users.Update(user);
            _applicationDbContext.SaveChanges();
        }
    }
}
