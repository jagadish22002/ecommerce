using ecommerce.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public Guid ProductId { get; set; } = Guid.NewGuid();

    [Required]
    [ForeignKey("Merchant")]
    public Guid MerchantId { get; set; }
    public Merchant Merchant { get; set; } = null!;

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public int ProductQuantity { get; set; }

    [Required]
    public decimal Price { get; set; }

    // Product availability is true if quantity > 0
    [NotMapped]
    public bool IsAvailable => ProductQuantity > 0;

    // Add this for EF Core relationship
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
