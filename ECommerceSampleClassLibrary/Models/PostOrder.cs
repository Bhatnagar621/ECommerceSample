namespace ECommerceSampleClassLibrary.Models
{
    public class PostOrder
    {
        public Guid CustomerId { get; set; }
        public required IDictionary<Guid, int> ProductIdAndQuantity { get; set; }
    }
}
