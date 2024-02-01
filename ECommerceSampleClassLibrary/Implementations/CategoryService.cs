using ECommerceSampleClassLibrary.Interfaces;
using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;
using ECommerceSampleClassLibrary.Repositories;
using ECommerceSampleClassLibrary.Context;

namespace ECommerceSampleClassLibrary.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly Repository<Category> _repository 
            = new Repository<Category>(new AppDbContext());

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
            return new ViewCategory(_repository.Get(id));
        }
    }
}
