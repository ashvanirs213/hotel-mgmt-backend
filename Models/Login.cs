namespace OnlineHotelManagementAPI.Models
{
    public class Login
    {
        public string Username { get; set; } 

        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } 
    }
}
