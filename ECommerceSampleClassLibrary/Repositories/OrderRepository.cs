using ECommerceSampleClassLibrary.Context;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSampleClassLibrary.Repositories
{
    public class OrderRepository: IOrderService
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public Guid AddOrder(PostOrder order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<ViewOrder>? GetOrdersByCustomers(IRepository<Order> _orderRepo, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
