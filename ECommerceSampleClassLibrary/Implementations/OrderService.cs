using ECommerceSampleClassLibrary.Context;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> _prodRepository;
        private readonly IRepository<Customer> _customerRepository;

        public OrderService(IRepository<Order> repository, IRepository<Product> prodRepository, IRepository<Customer> customerRepository)
        {
            _repository = repository;
            _prodRepository = prodRepository;
            _customerRepository = customerRepository;
        }

        public Guid AddOrder(PostOrder order)
        {
            var orderDetails = new Order()
            {
                CustomerId = order.CustomerId,
                Products = _prodRepository.GetAll(order.ProductIds),
                Quantity = order.Quantity,
                Status = "Placed"
            };
            _repository.Add(orderDetails);
            return orderDetails.Id;
            
        }

        public void DeleteOrder(Guid id)
        {
            _repository.Delete(_repository.Get(id));
        }

        public void UpdateOrder(Guid id, PostOrder order)
        {
            
        }
    }
}
