namespace task.core.DTOs.Enrollments
{
    public class AvailableSubjectForStudentDTO
    {
        public int SubjectId { get; set; }
        public string NameSubject { get; set; } = string.Empty;
        public int CreditsSubject { get; set; }
        public string? DescriptionSubject { get; set; }
        public int AvailableProfessors { get; set; }
        public int EnrolledStudents { get; set; }
    }
}