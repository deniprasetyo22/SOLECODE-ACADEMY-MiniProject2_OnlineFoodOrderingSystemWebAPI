using MiniProject2_OnlineFoodOrderingSystemWebAPI.Interfaces;
using MiniProject2_OnlineFoodOrderingSystemWebAPI.Models;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Services
{
    public class CustomerService:ICustomerService
    {
        private static List<Customer> _customerList = new List<Customer>();
        public void AddCustomer(Customer customer)
        {
            customer.CustomerId = _customerList.Count + 1;
            customer.RegistrationDate = DateTime.Now;
            _customerList.Add(customer);
        }
        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customerList;
        }
        public Customer GetCustomerById(int customerId)
        {
            return _customerList.Find(cek => cek.CustomerId == customerId);
        }
        public bool UpdateCustomer(int  customerId, Customer editCustomer)
        {
            var existingCustomer = _customerList.Find(cek=>cek.CustomerId == customerId);
            if (existingCustomer == null)
            {
                return false;
            }
            existingCustomer.Name = editCustomer.Name;
            existingCustomer.Email = editCustomer.Email;
            existingCustomer.PhoneNumber = editCustomer.PhoneNumber;
            existingCustomer.Address = editCustomer.Address;
            return true;
        }
        public bool DeleteCustomer(int customerId)
        {
            var deleteCustomer = _customerList.Find(cek => cek.CustomerId == customerId);
            if (deleteCustomer == null)
            {
                return false;
            }
            _customerList.Remove(deleteCustomer);
            return true;
        }

    }
}
