using FourWheel.Web.Models;
using System.Collections.Generic;

namespace FourWheel.Web.Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer cust);
        List<Customer> GetAllCustomers();
        Customer GetSpecificCustomer(int id);
        Customer UpdateCustomer(Customer cust);
        void DeleteCustomer(int id);
    }
}
