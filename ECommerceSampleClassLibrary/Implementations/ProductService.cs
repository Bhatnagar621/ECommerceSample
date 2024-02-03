using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Exceptions;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;

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

        public ICollection<ViewProduct> GetAllProduct()
        {
            ICollection<ViewProduct> productList = new List<ViewProduct>();
            var prods = _repository.GetAll(null);
            foreach (var product in prods)
            {
                productList.Add(new ViewProduct(product, _catrepository));
            }
            return productList;
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
            CheckEntityFoundError(id);
            _repository.Delete(_repository.Get(id));
        }

        public ViewProduct GetProductById(Guid id)
        {
            CheckEntityFoundError(id); 
           return new ViewProduct(_repository.Get(id), _catrepository);
        }

        public void UpdateProduct(Guid id, PostProduct product)
        {
            CheckEntityFoundError(id);
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

        public void CheckEntityFoundError(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return;
            }
            else
            {
                throw new EntityNotFoundException("product not found");
            }
        }

    }
}
