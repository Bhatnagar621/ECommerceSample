namespace ECommerceSampleClassLibrary.Domains
{
    public class Order: BaseDomain
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get;  }
        public virtual ICollection<OrderProduct> Products { get; set; }
        public string Status { get; set; }
    }
}
