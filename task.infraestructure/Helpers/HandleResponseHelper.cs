using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task.core.DTOs.Response;
using task.core.Interfaces.Services;

namespace task.infraestructure.Helpers
{
    public class HandleResponseHelper
    {
        public static async Task<ActionResult> HandleResponse(Func<Task<ResponseDTO>> action, ILogService _logService, string controllerName)
        {
            try
            {
                ResponseDTO response = await action.Invoke();

                return new OkObjectResult(response);

            }
            catch (ValidationException ex)
            {
                _logService.SaveLogsMessagesAsync($"Error desde :: {controllerName} :: {ex.Message}");
                return new BadRequestObjectResult(new ResponseDTO { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logService.SaveLogsMessagesAsync($"Error desde :: {controllerName} :: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}
