using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerById(int customerId);
        bool UpdateCustomer(int customerId, Customer editCustomer);
        bool DeleteCustomer(int customerId);
    }
}
