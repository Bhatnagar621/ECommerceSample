using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Customer> _customerRepository;
        public LoginService(IConfiguration configuration, IRepository<Customer> customerRepository)
        {
            _configuration = configuration;
            _customerRepository = customerRepository;
        }

        public ViewCustomer Authenticate(UserLogin userLogin)
        {
            var currentUser = _customerRepository.GetAll(null).FirstOrDefault
                (
                    x => 
                    x.Email.ToLower() == userLogin.Email.ToLower() 
                    && x.Password == userLogin.Password
                );
            if (currentUser != null)
            {
                return new ViewCustomer(currentUser);
            }
            return null;
        }

        public string GenerateToken(ViewCustomer user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(10),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
