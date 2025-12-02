namespace task.core.DTOs.Professors
{
    public class GetFilterProfessorsDTO
    {
        public string? SearchTerm { get; set; }
        public bool? IsActive { get; set; }
    }
}