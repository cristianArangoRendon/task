namespace task.core.DTOs.Students
{
    public class UpdateStudentDTO
    {
        public int StudentId { get; set; }
        public string? NameUser { get; set; }
        public string? EmailUser { get; set; }
        public string? PhoneUser { get; set; }
    }
}