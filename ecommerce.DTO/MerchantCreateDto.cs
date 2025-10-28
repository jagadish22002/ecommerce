using System;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class MerchantCreateDto
    {
        [Required]
        public string MerchantName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string MobileNumber { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string? Location { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
