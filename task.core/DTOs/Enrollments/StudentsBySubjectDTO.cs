namespace task.core.DTOs.Enrollments
{
    public class StudentsBySubjectDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public int ProfessorId { get; set; }
        public string NameProfessor { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public int EnrollmentId { get; set; }
    }
}
