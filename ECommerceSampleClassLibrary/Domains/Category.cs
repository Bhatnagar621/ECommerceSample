namespace ECommerceSampleClassLibrary.Domains
{
    public class Category: BaseDomain
    {
        public string Name {  get; set; }
        public virtual Product Product { get; } 
    }
}
