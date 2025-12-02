namespace task.core.DTOs.ProfessorSubjects
{
    public class ProfessorSubjectMapDataDTO
    {
        public int ProfessorSubjectId { get; set; }
        public int ProfessorId { get; set; }
        public string NameProfessor { get; set; } = string.Empty;
        public string EmailProfessor { get; set; } = string.Empty;
        public int SubjectId { get; set; }
        public string NameSubject { get; set; } = string.Empty;
        public int CreditsSubject { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EnrolledStudents { get; set; }
    }
}
