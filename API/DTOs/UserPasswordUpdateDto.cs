namespace API.DTOs
{
    public class UserPasswordUpdateDto
    {
        public int UserId { get;set; }
        public string Password { get; set; }
        public string PasswordNew { get; set; }
        public string PasswordConfirm { get; set; }
            
    }
}