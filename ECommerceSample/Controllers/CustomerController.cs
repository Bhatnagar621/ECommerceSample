using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
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
        [HttpGet("get/{id}")]
        public ViewCustomer GetCustomerById(Guid id)
        {
            return _customerService.GetCustomerById(id);
        }

        [HttpPost("add")]
        public Guid AddCustomer(PostCustomer customer)
        {
            return _customerService.AddCustomer(customer);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteCustomer(Guid id) 
        { 
            _customerService.DeleteCustomer(id);
        }
    }
}
