namespace task.core.DTOs.Tasks
{
    public class GetFilterTasksDTO
    {
        public int? TaskStatusId { get; set; } = null;
        public string? SearchTerm { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
