namespace task.core.DTOs.Enrollments
{
    public class ClassmateDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
    }
}