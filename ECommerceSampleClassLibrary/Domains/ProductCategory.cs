namespace ECommerceSampleClassLibrary.Domains
{
    public class ProductCategory: BaseDomain
    {
        public string Name {  get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
