namespace ECommerceSampleClassLibrary.Domains
{
    public class Order: BaseDomain
    {
        public Customer Customer { get; set; } = new Customer();
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
