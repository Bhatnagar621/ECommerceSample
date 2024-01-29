namespace ECommerceSampleClassLibrary.Domains
{
    public class Order: BaseDomain
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
