using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("{id}")]
        public ViewCustomer GetAllDetails(Guid id)
        {
            return _customerService.GetOrdersByCustomers(id);
        }

        [HttpPost]
        public Guid AddCustomer(PostCustomer customer)
        {
            return _customerService.AddCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomer(Guid id) 
        { 
            _customerService.DeleteCustomer(id);
        }

        [HttpPatch("{id}")]
        public void UpdateCustomer(Guid id, PostCustomer customer)
        {
            _customerService.UpdateCustomer(id, customer);
        }
    }
}
