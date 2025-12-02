namespace task.core.DTOs.Professor
{
    public class ProfessorSubjectDTO
    {
        public int SubjectId { get; set; }
        public string NameSubject { get; set; } = string.Empty;
        public int CreditsSubject { get; set; }
        public string? DescriptionSubject { get; set; }
        public int ProfessorSubjectId { get; set; }
        public DateTime AssignedAt { get; set; }
        public int EnrolledStudents { get; set; }
    }
}
