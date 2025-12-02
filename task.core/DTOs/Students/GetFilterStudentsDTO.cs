namespace task.core.DTOs.Students
{
    public class GetFilterStudentsDTO
    {
        public string? SearchTerm { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}