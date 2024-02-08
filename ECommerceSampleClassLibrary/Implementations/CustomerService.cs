using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Enums;
using ECommerceSampleClassLibrary.Exceptions;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<OrderProduct> _orderProductRepo;
        private readonly IRepository<Product> _productRepo;

        public CustomerService(IRepository<Customer> repository, IRepository<Order> orderRepo, IRepository<OrderProduct> orderProductRepo, IRepository<Product> productRepo)
        {
            _repository = repository;
            _orderRepo = orderRepo;
            _orderProductRepo = orderProductRepo;
            _productRepo = productRepo;
        }

        [AllowAnonymous]
        public Guid AddCustomer(PostCustomer customer)
        {
            var customerEntity = new Customer()
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Password = customer.Password,
                Roles = customer.Role
            };
            _repository.Add(customerEntity);
            return customerEntity.Id;
        }

        public void DeleteCustomer(Guid id)
        {
            if (CheckEntityFoundError(id))
                _repository.Delete(_repository.Get(id));
            else throw new EntityNotFoundException("customer not found");
        }

        public ViewCustomer GetOrdersByCustomers(Guid id)
        {
            if (CheckEntityFoundError(id))
            {
                var orders =
                (from order in _orderRepo.GetAll(null).ToList()
                 where order.CustomerId == id
                 join product in _orderProductRepo.GetAll(null) on order.Id equals product.OrderId into orderProducts
                 from joined in orderProducts.DefaultIfEmpty()
                 select new ViewOrder()
                 {
                     ProductName = _productRepo.Get(joined.ProductId).Name, // Handle potential nulls
                     ProductQuantity = joined?.Quantity ?? 0 // Set default for null Quantity
                 }).ToList();
                return new ViewCustomer(_repository.Get(id), orders);
            }
            else
                throw new EntityNotFoundException("customer not found");

        }

        public void UpdateCustomer(Guid id, PostCustomer customer)
        {
            if (CheckEntityFoundError(id))
            {
                var customerEntity = new Customer()
                {
                    Id = id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                };
                _repository.Update(customerEntity);
            }
            else throw new EntityNotFoundException("customer not found");


        }

        public bool CheckEntityFoundError(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
