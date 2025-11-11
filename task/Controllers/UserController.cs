using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Paginator;
using task.core.DTOs.Users;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController(ILogService logService, IUserUseCase useCase) : ControllerBase
    {
        private readonly IUserUseCase _userUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Obtener lista de usuarios con filtros y paginación
        /// </summary>
        /// <remarks>
        /// Permite filtrar usuarios por múltiples criterios y obtener resultados paginados
        /// </remarks>
        /// <response code="200">Lista de usuarios obtenida exitosamente</response>
        /// <response code="401">No autorizado - Token inválido o expirado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers(
            [FromQuery] PaginatorDTO? paginator,
            [FromQuery] GetFilterUsersDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _userUseCase.GetListUsers(paginator, filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Crear un nuevo usuario
        /// </summary>
        /// <remarks>
        /// Crea un nuevo usuario en el sistema con la información proporcionada
        /// </remarks>
        /// <response code="201">Usuario creado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="401">No autorizado</response>
        /// <response code="409">El usuario ya existe</response>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
          => await HandleResponseHelper.HandleResponse(
              () => _userUseCase.CreateUser(createUserDTO),
              _logService,
              MethodBase.GetCurrentMethod()?.Name ?? string.Empty
          );

        /// <summary>
        /// Actualizar un usuario existente
        /// </summary>
        /// <remarks>
        /// Actualiza la información de un usuario existente
        /// </remarks>
        /// <param name="userId">ID del usuario a actualizar</param>
        /// <param name="updateUserDTO">Datos actualizados del usuario</param>
        /// <response code="200">Usuario actualizado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Usuario no encontrado</response>
        [HttpPut("{userId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] int userId,
            [FromBody] UpdateUserDTO updateUserDTO)
        {

            return await HandleResponseHelper.HandleResponse(
                () => _userUseCase.UpdateUser(updateUserDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
        }

        /// <summary>
        /// Eliminar un usuario (borrado lógico)
        /// </summary>
        /// <remarks>
        /// Realiza un borrado lógico del usuario, marcándolo como inactivo
        /// </remarks>
        /// <param name="userId">ID del usuario a eliminar</param>
        /// <response code="200">Usuario eliminado exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Usuario no encontrado</response>
        [HttpDelete("{userId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
          => await HandleResponseHelper.HandleResponse(
              () => _userUseCase.DeleteUser(userId),
              _logService,
              MethodBase.GetCurrentMethod()?.Name ?? string.Empty
          );

        /// <summary>
        /// Obtener imagen de usuario en formato Base64
        /// </summary>
        /// <remarks>
        /// Recupera una imagen de usuario codificada en Base64 por nombre de archivo
        /// </remarks>
        /// <param name="fileName">Nombre del archivo de imagen</param>
        /// <param name="fileType">Tipo de archivo (1=Avatar, 2=Documento, etc.)</param>
        /// <response code="200">Imagen obtenida exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Imagen no encontrada</response>
        [HttpGet("images/{fileName}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserImage(
            [FromRoute] string fileName,
            [FromQuery] int fileType)
        => await HandleResponseHelper.HandleResponse(
            () => _userUseCase.GetBase64ImageByFileName(fileName, fileType),
            _logService,
            MethodBase.GetCurrentMethod()?.Name ?? string.Empty
        );
    }
}