namespace task.core.DTOs.TaskStatus
{
    public class GetFilterTaskStatusDTO
    {
        public bool? IsActive { get; set; }
        public string? SearchTerm { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
