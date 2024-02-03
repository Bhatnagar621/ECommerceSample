using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;

namespace ECommerceSampleClassLibrary.Models
{
    public class ViewProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public string Category { get; set; }

        public ViewProduct() { }
        public ViewProduct(Product product, IRepository<Category> _catrepository) {
            Name = product.Name;
            Measurement = product.Measurement;
            Quantity = product.Quantity;
            Category = _catrepository.Get(product.CategoryId).Name;    
        }
    }
}
