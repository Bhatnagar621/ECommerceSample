using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceSample.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryRepository;
        public CategoryController(ICategoryService categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("get/{id}")]
        public ViewCategory GetCategory(Guid id)
        {
            return _categoryRepository.GetCategory(id);
        }

        [HttpPost("add")]
        public Guid AddCategory(PostCategory category)
        {
            return _categoryRepository.AddCategory(category);
        }
    }
}
