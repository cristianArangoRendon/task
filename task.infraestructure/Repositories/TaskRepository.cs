using System.Threading.Tasks;
using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Tasks;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class TaskRepository(IExecuteStoreProcedureService service) : ITaskRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> CreateTask(CreateTaskDTO task)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.CreateTask",
                ObjectExtensionsHelper.ToObject<CreateTaskDTO>(task)
            );
        }

        public async Task<ResponseDTO> UpdateTask(UpdateTaskDTO task)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.UpdateTask",
                ObjectExtensionsHelper.ToObject<UpdateTaskDTO>(task)
            );
        }

        public async Task<ResponseDTO> DeleteTask(int taskId)
        {
            object obj = new
            {
                TaskId = taskId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.DeleteTask",
                obj
            );
        }

        public async Task<ResponseDTO> GetListTasks(GetFilterTasksDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetListTasks",
                ObjectExtensionsHelper.ToObject<GetFilterTasksDTO>(filters),
                MapToListHelper.MapToList<TaskMapDataListDTO>
            );
        }

        public async Task<ResponseDTO> GetTaskById(int taskId)
        {
            object obj = new
            {
                TaskId = taskId
            };
            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetTaskById",
                obj,
                MapToObjHelper.MapToObj<TaskMapDataByIdDTO>
            );
        }

        public async Task<ResponseDTO> GetTaskMetrics()
        {

            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetTaskMetrics",
                new {},
                MapToObjHelper.MapToObj<GetTaskMetricsDTO>
            );
        }
    }
}