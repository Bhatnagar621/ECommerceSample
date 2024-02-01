using ECommerceSampleClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSampleClassLibrary.Interfaces
{
    public interface IOrderService
    {
        public void AddOrder(PostOrder order);
        public void UpdateOrder(PostOrder order);
        public void DeleteOrder(Guid id);
    }
}
