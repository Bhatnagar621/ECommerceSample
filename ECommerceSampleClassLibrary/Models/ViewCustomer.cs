﻿using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Enums;
using ECommerceSampleClassLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSampleClassLibrary.Models
{
    public class ViewCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public RolesEnum Role { get; set; }
        public ICollection<ViewOrder>? Orders { get; set; }

        public ViewCustomer(Customer customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
            Role = customer.Roles;
        }
        public ViewCustomer(Customer customer, ICollection<ViewOrder>? orders)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
            Role = customer.Roles;
            Orders = orders;
        }
    }
}
