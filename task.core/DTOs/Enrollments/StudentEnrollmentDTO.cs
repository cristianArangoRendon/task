namespace task.core.DTOs.Enrollments
{
    public class StudentEnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public int SubjectId { get; set; }
        public string NameSubject { get; set; } = string.Empty;
        public int CreditsSubject { get; set; }
        public string? DescriptionSubject { get; set; }
        public int ProfessorId { get; set; }
        public string NameProfessor { get; set; } = string.Empty;
        public string EmailProfessor { get; set; } = string.Empty;
        public string? PhoneProfessor { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }
    }
}