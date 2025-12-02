namespace task.core.DTOs.Authentication
{
    public class LoginRequestDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsStudent { get; set; } = false; 
    }
}
