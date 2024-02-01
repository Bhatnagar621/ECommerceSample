using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;

namespace ECommerceSampleClassLibrary.Interfaces
{
    public interface IProductService
    {
        public Guid AddProduct(PostProduct product);
        public void UpdateProduct(PostProduct product);
        public void DeleteProduct(Guid id);
        public ViewProduct GetProductById(Guid id);
    }
}
