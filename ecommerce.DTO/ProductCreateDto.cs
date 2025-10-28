namespace ecommerce.DTOs
{
    public class ProductCreateDto
    {
        public Guid MerchantId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }
    }
}
