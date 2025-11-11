namespace task.core.DTOs.Tasks
{
    public class UpdateTaskDTO
    {
        public int TaskId { get; set; }
        public string? TitleTask { get; set; }
        public string? DescriptionTask { get; set; }
        public int? TaskStatusId { get; set; }
    }
}
