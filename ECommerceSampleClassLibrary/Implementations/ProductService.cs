using ECommerceSampleClassLibrary.Context;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<Category> _catrepository;

        public ProductService(IRepository<Product> repository, IRepository<Category> catrepository)
        {
            _repository = repository;
            _catrepository = catrepository;
        }   

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

        public void UpdateProduct(Guid id, PostProduct product)
        {
            var prod = new Product()
            {
                Id = id,
                Name = product.Name,
                Quantity = product.Quantity,
                Measurement = product.Measurement,
                CategoryId = product.CategoryId,
            };
            _repository.Update(prod);
        }
    }
}
