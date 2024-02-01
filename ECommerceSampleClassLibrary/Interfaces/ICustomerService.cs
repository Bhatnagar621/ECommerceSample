using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSampleClassLibrary.Interfaces
{
    public interface ICustomerService
    {
        public void AddCustomer(PostCustomer customer);
        public void UpdateCustomer(PostCustomer customer);
        public void DeleteCustomer(Guid id);
        public ViewCustomer GetCustomerById(Guid id);
        public ViewCustomer GetCustomerByEmail(string email);
    }
}
