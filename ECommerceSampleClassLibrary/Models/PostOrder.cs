namespace ECommerceSampleClassLibrary.Models
{
    public class PostOrder
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
