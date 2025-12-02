namespace task.core.DTOs.Students
{

    public class StudentMapDataByIdDTO
    {
        public int StudentId { get; set; }
        public string NameUser { get; set; } = string.Empty;
        public string EmailUser { get; set; } = string.Empty;
        public string? PhoneUser { get; set; }
        public bool IsActiveUser { get; set; }
        public DateTime CreatedAtUser { get; set; }
        public DateTime UpdatedAtUser { get; set; }
        public int EnrolledCredits { get; set; }
        public int EnrolledSubjects { get; set; }
    }
}
