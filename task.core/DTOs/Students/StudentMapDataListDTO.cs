namespace task.core.DTOs.Students
{
    public class StudentMapDataListDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber{ get; set; }
        public bool IsActive { get; set; }
    }
}
