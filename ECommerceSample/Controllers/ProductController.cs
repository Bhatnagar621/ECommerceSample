using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //[HttpGet("get/{id}")]
        //public Product GetProductById(Guid id)
        //{
        //    return _productRepository.Get(id);
        //}

        [HttpPost("add")]
        public void AddProduct([FromBody] ProductCategory product)
        {
            _productRepository.Add(product);
        }
    }
}
