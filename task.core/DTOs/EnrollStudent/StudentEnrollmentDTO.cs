namespace task.core.DTOs.EnrollStudent
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
        public DateTime EnrollmentDate { get; set; }
    }
}
