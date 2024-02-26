using Fribergs_Alpha.Models;

namespace Fribergs_Alpha.Data
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByEmail(string customerEmail);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
