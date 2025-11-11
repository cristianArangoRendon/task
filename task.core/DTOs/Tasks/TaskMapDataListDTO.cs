namespace task.core.DTOs.Tasks
{
    public class TaskMapDataListDTO
    {
        public int TaskId { get; set; }
        public string TitleTask { get; set; } = string.Empty;
        public string? DescriptionTask { get; set; }
        public int TaskStatusId { get; set; }
        public string NameTaskStatus { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
