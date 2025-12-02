namespace task.core.DTOs.Subjects
{
    public class UpdateSubjectDTO
    {
        public int SubjectId { get; set; }
        public string? NameSubject { get; set; }
        public int? CreditsSubject { get; set; }
        public string? DescriptionSubject { get; set; }
    }
}
