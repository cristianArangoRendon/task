namespace task.core.DTOs.Students
{
    public class CreateStudentDTO
    {
        public string NameUser { get; set; } = string.Empty;
        public string EmailUser { get; set; } = string.Empty;
        public string? PhoneUser { get; set; }
        public string PasswordHashUser { get; set; } = string.Empty;
        public string PasswordSaltUser { get; set; } = string.Empty;
    }
}
