using System.ComponentModel.DataAnnotations;
namespace FoodDeliveryAppWA.Models{
    public class UserModel
    {
        public int userId { get; set; }
        public string? userName { get; set; }
        public double userNumber { get; set; }
        public string? userAddress1 { get; set; }
        public string? userAddress2 { get; set; }
        public string? userRole { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string? userEmail { get; set; }
        public DateTime userDOB { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[a-zA-Z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string? userPassword { get; set; }
        public bool userAvailability { get; set; } = false;
        public int deliveryId { get; set; }
        public int customerId { get; set; }
    }
}