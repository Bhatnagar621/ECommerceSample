using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly Repository<Category> _repository 
            = new Repository<Category>();

        public void AddCategory(PostCategory category)
        {
            var categoryEntity = new Category()
            {
               Name = category.Name 
            };
            _repository.Add(categoryEntity);
        }

        public ViewCategory GetCategory(Guid id)
        {
            var cat = _repository.Get(id);
            return new ViewCategory()
            {
                Name = cat.Name,
            };
        }
    }
}
