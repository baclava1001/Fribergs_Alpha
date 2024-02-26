using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void AddCustomer(Customer customer)
        {
            _applicationDbContext.Customers.Add(customer);
            _applicationDbContext.SaveChanges();           
        }

        public void DeleteCustomer(Customer customer)
        {
            _applicationDbContext.Remove(customer);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
           return _applicationDbContext.Customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
        }

        public Customer GetCustomerByEmail(string customerEmail)
        {
            return _applicationDbContext.Customers.FirstOrDefault(c => c.Email == customerEmail);
        }

        public Customer GetCustomerById(int customerId)
        {
            return _applicationDbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            _applicationDbContext.Update(customer);
            _applicationDbContext.SaveChanges();
        }
    }
}
