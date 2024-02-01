using ECommerceSampleClassLibrary.Domains;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSampleClassLibrary.Models
{
    public class ViewCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ViewCustomer() { }
        public ViewCustomer(Customer customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
        }
    }
}
