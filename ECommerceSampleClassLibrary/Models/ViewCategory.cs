using ECommerceSampleClassLibrary.Domains;

namespace ECommerceSampleClassLibrary.Models
{
    public class ViewCategory
    {
        public string Name { get; set; }

        public ViewCategory() { }
        public ViewCategory(Category category) {
            Name = category.Name;
        }
    }
}
