using ECommerceSampleClassLibrary.Context;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class ProductService : IProductService
    {
        private readonly Repository<Product> _repository
                             = new Repository<Product>(new AppDbContext());
        private readonly Repository<Category> _catrepository
                     = new Repository<Category>(new AppDbContext());

        public Guid AddProduct(PostProduct product)
        {
            var productEntity = new Product()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Measurement = product.Measurement,
                CategoryId = product.CategoryId,
            };

            _repository.Add(productEntity);
            return productEntity.Id;
        }

        public void DeleteProduct(Guid id)
        {
            var productEntity = _repository.Get(id);
            if (productEntity != null)
            {
                _repository.Delete(productEntity);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public ViewProduct GetProductById(Guid id)
        {
           return new ViewProduct(_repository.Get(id), _catrepository);
        }

        public void UpdateProduct(PostProduct product)
        {
            var prod = new Product()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Measurement = product.Measurement,
                CategoryId = product.CategoryId,
            };
            _repository.Update(prod);
        }
    }
}
