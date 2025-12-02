using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Students;
using task.core.DTOs.Users;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class UserRepository(IExecuteStoreProcedureService service) : IUserRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> CreateUser(CreateUserDTO user)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.CreateUser",
                ObjectExtensionsHelper.ToObject<CreateUserDTO>(user)
            );
        }

        public async Task<ResponseDTO> DeleteUser(int userId)
        {
            object obj = new
            {
                UserId = userId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.DeleteUsers",
                obj
            );
        }

        public async Task<ResponseDTO> GetListUsers(PaginatorDTO? paginator, GetFilterUsersDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetListUsers",
                ObjectExtensionsHelper.ToObject<GetFilterUsersDTO>(filters),
                MapToListHelper.MapToList<UserMapDataListDTO>
            );
        }

        public async Task<ResponseDTO> GetUserById(int userId)
        {
            object obj = new
            {
                UserId = userId
            };
            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetUserById",
                obj,
                MapToObjHelper.MapToObj<UserMapDataByIdDTO>
            );
        }

        public async Task<ResponseDTO> UpdateUser(UpdateUserDTO user)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.UpdateUser",
                ObjectExtensionsHelper.ToObject<UpdateUserDTO>(user)
            );
        }

        public async Task<ResponseDTO> GetUserByEmail(string email)
        {
            object obj = new
            {
                EmailUser = email
            };
            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetUserByEmail",
                obj,
                MapToObjHelper.MapToObj<UserMapDataByIdDTO>
            );
        }

        public async Task<ResponseDTO> GetAllStudents(PaginatorDTO? paginator, GetFilterUsersDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetAllStudents",
                ObjectExtensionsHelper.ToObject<GetFilterUsersDTO>(filters),
                MapToListHelper.MapToList<StudentMapDataListDTO>
            );
        }
    }
}
