using System.Text.Json.Serialization;

namespace task.core.DTOs.Users
{
    public class CreateUserDTO
    {
        public string NameUser { get; set; } = string.Empty;
        public string EmailUser { get; set; } = string.Empty;
        public string? PhoneUser { get; set; }
        public string? SpecialitiesUser { get; set; }
        public string PasswordHashUser { get; set; } = string.Empty;
        [JsonIgnore]
        public string PasswordSaltUser { get; set; } = string.Empty;
        public string? UserImage { get; set; }
    }
}
