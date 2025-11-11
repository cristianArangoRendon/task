using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.TaskStatus;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class TaskStatusRepository(IExecuteStoreProcedureService service) : ITaskStatusRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> CreateTaskStatus(CreateTaskStatusDTO taskStatus)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.CreateTaskStatus",
                ObjectExtensionsHelper.ToObject<CreateTaskStatusDTO>(taskStatus)
            );
        }

        public async Task<ResponseDTO> UpdateTaskStatus(UpdateTaskStatusDTO taskStatus)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.UpdateTaskStatus",
                ObjectExtensionsHelper.ToObject<UpdateTaskStatusDTO>(taskStatus)
            );
        }

        public async Task<ResponseDTO> DeleteTaskStatus(int taskStatusId)
        {
            object obj = new
            {
                TaskStatusId = taskStatusId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.DeleteTaskStatus",
                obj
            );
        }

        public async Task<ResponseDTO> GetListTaskStatus(PaginatorDTO? paginator, GetFilterTaskStatusDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetListTaskStatus",
                ObjectExtensionsHelper.ToObject<GetFilterTaskStatusDTO>(filters),
                MapToListHelper.MapToList<TaskStatusMapDataListDTO>
            );
        }

        public async Task<ResponseDTO> GetTaskStatusById(int taskStatusId)
        {
            object obj = new
            {
                TaskStatusId = taskStatusId
            };
            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetTaskStatusById",
                obj,
                MapToObjHelper.MapToObj<TaskStatusMapDataByIdDTO>
            );
        }
    }
}