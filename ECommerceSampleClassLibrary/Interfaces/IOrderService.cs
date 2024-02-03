using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSampleClassLibrary.Interfaces
{
    public interface IOrderService
    {
        public Guid AddOrder(PostOrder order);
        public void DeleteOrder(Guid id);
    }
}
