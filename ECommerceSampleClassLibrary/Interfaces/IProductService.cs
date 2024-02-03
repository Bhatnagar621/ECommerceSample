using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;

namespace ECommerceSampleClassLibrary.Interfaces
{
    public interface IProductService
    {
        public Guid AddProduct(PostProduct product);
        public void UpdateProduct(Guid id, PostProduct product);
        public void DeleteProduct(Guid id);
        public ViewProduct GetProductById(Guid id);
        public ICollection<ViewProduct> GetAllProduct();
    }
}
