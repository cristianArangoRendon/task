using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.TaskStatus;

namespace task.core.Interfaces.UseCases
{
    public interface ITaskStatusUseCase
    {
        Task<ResponseDTO> CreateTaskStatus(CreateTaskStatusDTO taskStatus);
        Task<ResponseDTO> UpdateTaskStatus(UpdateTaskStatusDTO taskStatus);
        Task<ResponseDTO> DeleteTaskStatus(int taskStatusId);
        Task<ResponseDTO> GetListTaskStatus(PaginatorDTO? paginator, GetFilterTaskStatusDTO filters);
        Task<ResponseDTO> GetTaskStatusById(int taskStatusId);
    }
}
