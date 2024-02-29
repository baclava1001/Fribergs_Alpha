using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);

            if(user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public IEnumerable<User> GetAllCustomers()
        {
            return _dbContext.Users.Where(x => x.AdminRole == false).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public IEnumerable<User> GetAllAdmins()
        {
            return _dbContext.Users.Where(x => x.AdminRole == true).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserId == id);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
