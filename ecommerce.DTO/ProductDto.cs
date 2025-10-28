namespace ecommerce.DTOs
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public Guid MerchantId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}