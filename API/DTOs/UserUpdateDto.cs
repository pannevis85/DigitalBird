namespace API.DTOs
{
    public class UserUpdateDto
    {
        public int Userid { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public string Status { get; set; }
    }
}