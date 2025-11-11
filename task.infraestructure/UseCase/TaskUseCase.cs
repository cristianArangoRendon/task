using System.Threading.Tasks;
using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Tasks;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class TaskUseCase(ITaskRepository taskRepository, ILogService logService) : ITaskUseCase
    {
        private readonly ITaskRepository _taskRepository = taskRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> CreateTask(CreateTaskDTO task)
        {
            try
            {
                return await _taskRepository.CreateTask(task);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> UpdateTask(UpdateTaskDTO task)
        {
            try
            {
                return await _taskRepository.UpdateTask(task);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> DeleteTask(int taskId)
        {
            try
            {
                return await _taskRepository.DeleteTask(taskId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetListTasks(GetFilterTasksDTO filters)
        {
            try
            {
                return await _taskRepository.GetListTasks(filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetTaskById(int taskId)
        {
            try
            {
                return await _taskRepository.GetTaskById(taskId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetTaskMetrics()
        {
            try
            {
                return await _taskRepository.GetTaskMetrics();
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}