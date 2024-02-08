using System.ComponentModel.DataAnnotations;

namespace ECommerceSampleClassLibrary.Models
{
    public class UserLogin
    {
        [EmailAddress]
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}
