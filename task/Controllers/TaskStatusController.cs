using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Paginator;
using task.core.DTOs.TaskStatus;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class TaskStatusController(ILogService logService, ITaskStatusUseCase useCase) : ControllerBase
    {
        private readonly ITaskStatusUseCase _taskStatusUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Obtener lista de estados de tareas con filtros y paginación
        /// </summary>
        /// <response code="200">Lista de estados obtenida exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTaskStatus(
            [FromQuery] PaginatorDTO? paginator,
            [FromQuery] GetFilterTaskStatusDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _taskStatusUseCase.GetListTaskStatus(paginator, filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener estado de tarea por ID
        /// </summary>
        /// <param name="taskStatusId">ID del estado</param>
        /// <response code="200">Estado obtenido exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Estado no encontrado</response>
        [HttpGet("{taskStatusId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTaskStatusById([FromRoute] int taskStatusId)
            => await HandleResponseHelper.HandleResponse(
                () => _taskStatusUseCase.GetTaskStatusById(taskStatusId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Crear un nuevo estado de tarea
        /// </summary>
        /// <response code="201">Estado creado exitosamente</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="401">No autorizado</response>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateTaskStatus([FromBody] CreateTaskStatusDTO createTaskStatusDTO)
            => await HandleResponseHelper.HandleResponse(
                () => _taskStatusUseCase.CreateTaskStatus(createTaskStatusDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Actualizar un estado de tarea existente
        /// </summary>
        /// <param name="taskStatusId">ID del estado a actualizar</param>
        /// <param name="updateTaskStatusDTO">Datos actualizados del estado</param>
        /// <response code="200">Estado actualizado exitosamente</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Estado no encontrado</response>
        [HttpPut("{taskStatusId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTaskStatus(
            [FromRoute] int taskStatusId,
            [FromBody] UpdateTaskStatusDTO updateTaskStatusDTO)
        {
            if (updateTaskStatusDTO.TaskStatusId != taskStatusId)
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    Message = "TaskStatus ID mismatch between route and body"
                });
            }

            return await HandleResponseHelper.HandleResponse(
                () => _taskStatusUseCase.UpdateTaskStatus(updateTaskStatusDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
        }

        /// <summary>
        /// Eliminar un estado de tarea (borrado lógico)
        /// </summary>
        /// <param name="taskStatusId">ID del estado a eliminar</param>
        /// <response code="200">Estado eliminado exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Estado no encontrado</response>
        [HttpDelete("{taskStatusId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTaskStatus([FromRoute] int taskStatusId)
            => await HandleResponseHelper.HandleResponse(
                () => _taskStatusUseCase.DeleteTaskStatus(taskStatusId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
    }
}