namespace task.core.DTOs.Enrollments
{
    public class AllEnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public int SubjectId { get; set; }
        public string NameSubject { get; set; } = string.Empty;
        public int CreditsSubject { get; set; }
        public int ProfessorId { get; set; }
        public string NameProfessor { get; set; } = string.Empty;
        public string EmailProfessor { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
