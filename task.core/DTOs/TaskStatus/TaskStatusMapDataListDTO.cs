namespace task.core.DTOs.TaskStatus
{
    public class TaskStatusMapDataListDTO
    {
        public int TaskStatusId { get; set; }
        public string NameTaskStatus { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int TotalTasks { get; set; }
    }
}
