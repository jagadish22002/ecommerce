using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Data.Models
{
    public enum PaymentStatus
    {
        OnlinePaid,
        PayOnDelivery
    }

    public enum OrderStatus
    {
        Dispatched,
        Delivered
    }

    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();

        // Foreign key to User
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        // Foreign key to Product
        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        [Required]
        public OrderStatus DeliveryStatus { get; set; }
    }
}
