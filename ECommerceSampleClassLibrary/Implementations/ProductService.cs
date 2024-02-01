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
                             = new Repository<Product>();
        private readonly Repository<Category> _catrepository
                     = new Repository<Category>();

        public void AddProduct(PostProduct product)
        {
            var productEntity = new Product()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                Measurement = product.Measurement,
                CategoryId = product.CategoryId,
            };

            _repository.Add(productEntity);
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
            var prod =  _repository.Get(id);
            var prodInfo = new ViewProduct()
            {
                Name = prod.Name,
                Measurement = prod.Measurement,
                Quantity = prod.Quantity,
                Category = _catrepository.Get(prod.CategoryId).Name
            };
            return prodInfo;
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
