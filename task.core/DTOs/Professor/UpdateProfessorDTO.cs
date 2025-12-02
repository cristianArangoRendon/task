namespace task.core.DTOs.Professors
{
    public class UpdateProfessorDTO
    {
        public int ProfessorId { get; set; }
        public string? NameProfessor { get; set; }
        public string? EmailProfessor { get; set; }
        public string? PhoneProfessor { get; set; }
    }
}