namespace ecommerce.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
