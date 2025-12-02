namespace task.core.DTOs.ProfessorSubjects
{
    public class AvailableProfessorForSubjectDTO
    {
        public int ProfessorId { get; set; }
        public string NameProfessor { get; set; } = string.Empty;
        public string EmailProfessor { get; set; } = string.Empty;
        public string? PhoneProfessor { get; set; }
        public int AssignedSubjects { get; set; }
        public int TotalStudents { get; set; }
    }
}
