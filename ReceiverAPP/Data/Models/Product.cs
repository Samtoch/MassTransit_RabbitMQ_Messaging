namespace ReceiverAPP.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal Quantity { get; set;} = 0;
    }
}
 