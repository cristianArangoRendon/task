using task.core.DTOs.Response;
using task.core.Interfaces.Services;

namespace task.infraestructure.Helpers
{
    public static class ExceptionHelper
    {
        public static ResponseDTO HandleException(ILogService logService, string methodName, Exception ex)
        {
            logService.SaveLogsMessagesAsync($"An error occurred while executing BLL: {methodName}: {ex.Message}");
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
        }
    }
}
