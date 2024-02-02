namespace ECommerceSampleClassLibrary.Models
{
    public class PostOrder
    {
        public Guid CustomerId { get; set; }
        public ICollection<Guid> ProductIds { get; set; }
        public int Quantity { get; set; }
    }
}
