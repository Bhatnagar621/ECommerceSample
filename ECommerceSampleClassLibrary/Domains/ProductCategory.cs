namespace ECommerceSampleClassLibrary.Domains
{
    public class ProductCategory: BaseDomain
    {
        public string Name {  get; set; }
        public virtual ICollection<Product>? Products { get; } 
    }
}
