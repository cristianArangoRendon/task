using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Users;

namespace task.core.Interfaces.UseCases
{
    public interface IUserUseCase
    {
        Task<ResponseDTO> CreateUser(CreateUserDTO user);
        Task<ResponseDTO> UpdateUser(UpdateUserDTO user);
        Task<ResponseDTO> DeleteUser(int userId);
        Task<ResponseDTO> GetUserById(int userId);
        Task<ResponseDTO> GetListUsers(PaginatorDTO? paginator, GetFilterUsersDTO filters);
        Task<ResponseDTO> GetBase64ImageByFileName(string fileName, int fileType);
    }
}
