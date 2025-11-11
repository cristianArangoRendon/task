namespace task.core.DTOs.TaskStatus
{
    public class UpdateTaskStatusDTO
    {
        public int TaskStatusId { get; set; }
        public string? NameTaskStatus { get; set; }
        public bool? IsActive { get; set; }
    }
}
