using task.core.DTOs.Authentication;
using task.core.DTOs.Response;

namespace task.core.Interfaces.UseCases
{
    public interface IAuthenticationUseCase
    {
        Task<ResponseDTO> Authentication(LoginRequestDTO loginRequestDTO);
    }
}
