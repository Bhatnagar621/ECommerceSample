using ECommerceSampleClassLibrary.Context;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly Repository<Customer> _repository
                                    = new Repository<Customer>(new AppDbContext());

        public Guid AddCustomer(PostCustomer customer)
        {
            var customerEntity = new Customer()
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
            };
            _repository.Add(customerEntity);
            return customerEntity.Id;
        }

        public void DeleteCustomer(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                _repository.Delete(customer);
            }
            else
            {
                throw new Exception("Customer doesn't exists");
            }
        }

        public ViewCustomer GetCustomerById(Guid id)
        {
            return new ViewCustomer(_repository.Get(id));
        }

        public void UpdateCustomer(PostCustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}
