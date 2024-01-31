namespace ECommerceSampleClassLibrary.Models
{
    public class Order
    {
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
