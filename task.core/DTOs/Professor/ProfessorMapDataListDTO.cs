namespace task.core.DTOs.Professors
{
    public class ProfessorMapDataListDTO
    {
        public int ProfessorId { get; set; }
        public string NameProfessor { get; set; } = string.Empty;
        public string EmailProfessor { get; set; } = string.Empty;
        public string? PhoneProfessor { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AssignedSubjects { get; set; }
        public int TotalStudents { get; set; }
    }
}