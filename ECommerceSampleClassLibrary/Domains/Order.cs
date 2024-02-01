namespace ECommerceSampleClassLibrary.Domains
{
    public class Order: BaseDomain
    {
        public virtual Customer Customer { get; set; } = new Customer();
        public virtual ICollection<Product> Products { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
