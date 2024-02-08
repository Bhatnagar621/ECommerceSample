using ECommerceSampleClassLibrary.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSampleClassLibrary.Models
{
    public class PostCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public RolesEnum Role { get; set; } = RolesEnum.Customer;
    }
}
