using System.ComponentModel.DataAnnotations;

namespace ECommerceSampleClassLibrary.Models
{
    public class UserModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
