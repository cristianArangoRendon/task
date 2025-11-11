using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Tasks;

namespace task.core.Interfaces.UseCases
{
    public interface ITaskUseCase
    {
        Task<ResponseDTO> CreateTask(CreateTaskDTO task);
        Task<ResponseDTO> UpdateTask(UpdateTaskDTO task);
        Task<ResponseDTO> DeleteTask(int taskId);
        Task<ResponseDTO> GetListTasks( GetFilterTasksDTO filters);
        Task<ResponseDTO> GetTaskById(int taskId);
        Task<ResponseDTO> GetTaskMetrics();

    }
}
