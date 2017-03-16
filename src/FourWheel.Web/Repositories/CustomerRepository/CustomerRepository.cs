using FourWheel.Web.DataContext;
using FourWheel.Web.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FourWheel.Web.Repositories
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly FourWheelContext _fourWheelContext;

        public CustomerRepository(FourWheelContext fourWheelContext)
        {
            _fourWheelContext = fourWheelContext;
        }

        public void CreateCustomer(Customer cust)
        {
            _fourWheelContext.Customers.Add(cust);
            _fourWheelContext.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var ac = _fourWheelContext.Customers.Include(c => c.RegisteredCars).ThenInclude(r => r.Car).ToList();
            return ac;
        }

        public Customer GetSpecificCustomer(int id)
        {
            var ac = _fourWheelContext.Customers.Include(c => c.RegisteredCars).ThenInclude(r => r.Car).Where(m => m.Id == id).SingleOrDefault();
            return ac;
        }

        public Customer UpdateCustomer(Customer cust)
        {
            Customer ac = _fourWheelContext.Customers.Include(c => c.RegisteredCars).ThenInclude(r => r.Car).Where(m => m.Id == cust.Id).SingleOrDefault();
            ac.Name = cust.Name;
            ac.Phone = cust.Phone;
            ac.Address = cust.Address;
            _fourWheelContext.SaveChanges();
            return ac;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _fourWheelContext.Customers.Where(c => c.Id == id).FirstOrDefault();

            _fourWheelContext.Customers.Remove(customer);
            _fourWheelContext.SaveChanges();
        }
    }
}
