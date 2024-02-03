namespace ECommerceSampleClassLibrary.Domains
{
    public class Product: BaseDomain
    {
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public virtual ICollection<OrderProduct>? Orders { get; }
    }
}
