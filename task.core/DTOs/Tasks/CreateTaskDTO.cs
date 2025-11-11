namespace task.core.DTOs.Tasks
{
    public class CreateTaskDTO
    {
        public string TitleTask { get; set; } = string.Empty;
        public string? DescriptionTask { get; set; }
        public int TaskStatusId { get; set; } = 1;
    }
}
