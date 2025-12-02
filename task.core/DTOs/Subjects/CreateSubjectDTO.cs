namespace task.core.DTOs.Subjects
{
    public class CreateSubjectDTO
    {
        public string NameSubject { get; set; } = string.Empty;
        public int CreditsSubject { get; set; } = 3;
        public string? DescriptionSubject { get; set; }
    }
}
