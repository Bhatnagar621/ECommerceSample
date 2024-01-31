namespace ECommerceSampleClassLibrary.Domains
{
    public class Product: BaseDomain
    {
        public ProductCategory Category { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public ICollection<Order> Orders { get; }
    }
}
