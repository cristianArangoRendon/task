namespace task.core.DTOs.Authentication
{
    public class TokenResultDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
