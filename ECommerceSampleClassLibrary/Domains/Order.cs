namespace ECommerceSampleClassLibrary.Domains
{
    public class Order: BaseDomain
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get;  }
        public virtual ICollection<Product> Products { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
