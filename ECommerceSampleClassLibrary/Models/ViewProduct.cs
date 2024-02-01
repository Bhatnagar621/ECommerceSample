using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSampleClassLibrary.Models
{
    public class ViewProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public string Category { get; set; }

        public ViewProduct() { }
        public ViewProduct(Product product, Repository<Category> _catrepository) {
            Name = product.Name;
            Measurement = product.Measurement;
            Quantity = product.Quantity;
            Category = _catrepository.Get(product.CategoryId).Name;    
        }
    }
}
