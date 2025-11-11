using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Authentication;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [AllowAnonymous]

    public class AuthenticationController(
        IAuthenticationUseCase authenticationUseCase,
        ILogService logService) : ControllerBase
    {
        private readonly IAuthenticationUseCase _authenticationUseCase = authenticationUseCase ?? throw new ArgumentNullException(nameof(authenticationUseCase));
        private readonly ILogService _logService = logService ?? throw new ArgumentNullException(nameof(logService));


        [HttpPost("api/Authentication")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(object), 400)]
        [ProducesResponseType(typeof(object), 429)]
        [ProducesResponseType(typeof(object), 500)]
        public async Task<IActionResult> Authentication([FromBody] LoginRequestDTO request)
            => await HandleResponseHelper.HandleResponse(
                () => _authenticationUseCase.Authentication(
                  request
                ),
                _logService,
                MethodBase.GetCurrentMethod()?.Name
            );
        
    }
}
