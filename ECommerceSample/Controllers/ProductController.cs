
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productRepository;
        public ProductController(IProductService productrepository)
        {
            _productRepository = productrepository;
        }

        [HttpGet]
        public ICollection<ViewProduct> GetAllProducts()
        {
            return _productRepository.GetAllProduct();
        }

        [HttpGet("{id}")]
        public ViewProduct GetProduct(Guid id)
        {
            return _productRepository.GetProductById(id);
        }

        [HttpPut]
        public Guid AddProduct([FromBody] PostProduct prod)
        {
            return _productRepository.AddProduct(prod);
        }

        [HttpDelete]
        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }

        [HttpPatch("{id}")]
        public void UpdateProduct(Guid id, [FromBody] PostProduct prod) { 
            _productRepository.UpdateProduct(id, prod);
        }
    }
}
