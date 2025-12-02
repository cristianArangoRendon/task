namespace task.core.DTOs.ProfessorSubjects
{
    public class AvailableSubjectForProfessorDTO
    {
        public int SubjectId { get; set; }
        public string NameSubject { get; set; } = string.Empty;
        public int CreditsSubject { get; set; }
        public string? DescriptionSubject { get; set; }
        public int AssignedProfessors { get; set; }
    }
}
