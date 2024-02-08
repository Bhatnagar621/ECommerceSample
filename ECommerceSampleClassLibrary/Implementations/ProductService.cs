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
            if (CheckEntityFoundError(id))
                _repository.Delete(_repository.Get(id));
            else throw new EntityNotFoundException("customer not found");
        }

        public ViewProduct GetProductById(Guid id)
        {
            if (CheckEntityFoundError(id))
                return new ViewProduct(_repository.Get(id), _catrepository);
            else throw new EntityNotFoundException("customer not found");
        }

        public void UpdateProduct(Guid id, PostProduct product)
        {
            if (CheckEntityFoundError(id))
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
            else throw new EntityNotFoundException("customer not found");

        }

        public bool CheckEntityFoundError(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
