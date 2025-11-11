namespace task.core.DTOs.Users
{
    public class UserMapDataByIdDTO
    {
        public int UserId { get; set; }
        public string NameUser { get; set; } = string.Empty;
        public string EmailUser { get; set; } = string.Empty;
        public string? PhoneUser { get; set; }
        public string? SpecialitiesUser { get; set; }
        public bool IsActiveUser { get; set; }
        public DateTime CreatedAtUser { get; set; }
        public DateTime? UpdatedAtUser { get; set; }
        public string? UserImage { get; set; }
        public string PasswordHashUser { get; set; } = string.Empty;
        public string PasswordSaltUser { get; set; } = string.Empty;
    }
}
