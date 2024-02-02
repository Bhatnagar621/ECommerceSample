using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;
using ECommerceSampleClassLibrary.Context;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Guid AddCategory(PostCategory category)
        {
            var categoryEntity = new Category()
            {
               Name = category.Name 
            };
            _repository.Add(categoryEntity);
            return categoryEntity.Id;
        }

        public ViewCategory GetCategory(Guid id)
        {
            return new ViewCategory(_repository.Get(id));
        }
    }
}
