using Microsoft.AspNetCore.Mvc;
using FourWheel.Web.ViewModels;
using FourWheel.Web.Models;
using FourWheel.Web.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FourWheel.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Alle kunder";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel cvm)
        {
            ViewBag.Title = "Opret bruger";
            Customer cust = new Customer
            {
                Name = cvm.Name,
                Address = cvm.Address,
                Phone = cvm.Phone
            };

            _customerRepository.CreateCustomer(cust);

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult All(SeeCustomersViewModel vm)
        {
            ViewBag.Title = "Alle kunder";
            vm.customers = _customerRepository.GetAllCustomers();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Opdater kunde";
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetSpecificCustomer(id);

            EditCustomerViewModel ecv = new EditCustomerViewModel
            {
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                registeredcars = customer.RegisteredCars,
                Id = customer.Id
            };

            return View(ecv);
        }

        [HttpPost]
        public IActionResult Edit(EditCustomerViewModel esv)
        {
            ViewBag.Title = "Opdater kunde";
            Customer cust = new Customer
            {
                Id = esv.Id,
                Address = esv.Address,
                Name = esv.Name,
                Phone = esv.Phone
            };

            Customer updatedCustomer = _customerRepository.UpdateCustomer(cust);

            EditCustomerViewModel newUser = new EditCustomerViewModel
            {
                Name = updatedCustomer.Name,
                Phone = updatedCustomer.Phone,
                Address = updatedCustomer.Address,
                 registeredcars = updatedCustomer.RegisteredCars
            };

            return View(newUser);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Slet kunde";

            var customer = _customerRepository.GetSpecificCustomer(id);

            DeleteCustomerViewModel dcvm = new DeleteCustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address
            };

            return View(dcvm);
        }

        [HttpPost, ActionName("DeleteComment")]
        public IActionResult DeleteConfirmed(int id)
        {
            ViewBag.Title = "Slet kunde";

            _customerRepository.DeleteCustomer(id);

            return RedirectToAction("All");
        }
    }
}
