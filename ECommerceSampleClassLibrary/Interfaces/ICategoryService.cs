using ECommerceSampleClassLibrary.Domains;
using ECommerceSampleClassLibrary.Models;

namespace ECommerceSampleClassLibrary.Interfaces
{
    public interface ICategoryService
    {
        public void AddCategory(PostCategory category);
        public ViewCategory GetCategory(Guid id);
    }
}

