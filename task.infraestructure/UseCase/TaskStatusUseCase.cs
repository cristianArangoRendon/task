using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.TaskStatus;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class TaskStatusUseCase(ITaskStatusRepository taskStatusRepository, ILogService logService) : ITaskStatusUseCase
    {
        private readonly ITaskStatusRepository _taskStatusRepository = taskStatusRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> CreateTaskStatus(CreateTaskStatusDTO taskStatus)
        {
            try
            {
                return await _taskStatusRepository.CreateTaskStatus(taskStatus);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> UpdateTaskStatus(UpdateTaskStatusDTO taskStatus)
        {
            try
            {
                return await _taskStatusRepository.UpdateTaskStatus(taskStatus);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> DeleteTaskStatus(int taskStatusId)
        {
            try
            {
                return await _taskStatusRepository.DeleteTaskStatus(taskStatusId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetListTaskStatus(PaginatorDTO? paginator, GetFilterTaskStatusDTO filters)
        {
            try
            {
                return await _taskStatusRepository.GetListTaskStatus(paginator, filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetTaskStatusById(int taskStatusId)
        {
            try
            {
                return await _taskStatusRepository.GetTaskStatusById(taskStatusId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}