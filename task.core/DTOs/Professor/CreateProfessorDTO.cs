namespace task.core.DTOs.Professors
{
    public class CreateProfessorDTO
    {
        public string NameProfessor { get; set; } = string.Empty;
        public string EmailProfessor { get; set; } = string.Empty;
        public string? PhoneProfessor { get; set; }
    }
}