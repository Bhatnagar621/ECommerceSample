﻿using ECommerceSampleClassLibrary.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSampleClassLibrary.Domains
{
    public class Customer: BaseDomain
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public RolesEnum Roles { get; set; }
    }
}
