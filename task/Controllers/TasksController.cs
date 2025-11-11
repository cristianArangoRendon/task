using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Tasks;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class TasksController(ILogService logService, ITaskUseCase useCase) : ControllerBase
    {
        private readonly ITaskUseCase _taskUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Obtener lista de tareas con filtros y paginación
        /// </summary>
        /// <response code="200">Lista de tareas obtenida exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTasks(
            [FromQuery] GetFilterTasksDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _taskUseCase.GetListTasks(filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener métricas de tareas
        /// </summary>
        /// <response code="200">Métricas obtenidas exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("metrics")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTaskMetrics()
            => await HandleResponseHelper.HandleResponse(
                () => _taskUseCase.GetTaskMetrics(),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener tarea por ID
        /// </summary>
        /// <param name="taskId">ID de la tarea</param>
        /// <response code="200">Tarea obtenida exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Tarea no encontrada</response>
        [HttpGet("{taskId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTaskById([FromRoute] int taskId)
            => await HandleResponseHelper.HandleResponse(
                () => _taskUseCase.GetTaskById(taskId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Crear una nueva tarea
        /// </summary>
        /// <response code="201">Tarea creada exitosamente</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="401">No autorizado</response>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO createTaskDTO)
            => await HandleResponseHelper.HandleResponse(
                () => _taskUseCase.CreateTask(createTaskDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Actualizar una tarea existente
        /// </summary>
        /// <param name="taskId">ID de la tarea a actualizar</param>
        /// <param name="updateTaskDTO">Datos actualizados de la tarea</param>
        /// <response code="200">Tarea actualizada exitosamente</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Tarea no encontrada</response>
        [HttpPut("{taskId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTask(
            [FromRoute] int taskId,
            [FromBody] UpdateTaskDTO updateTaskDTO)
        {
            return await HandleResponseHelper.HandleResponse(
                () => _taskUseCase.UpdateTask(updateTaskDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
        }

        /// <summary>
        /// Eliminar una tarea (borrado lógico)
        /// </summary>
        /// <param name="taskId">ID de la tarea a eliminar</param>
        /// <response code="200">Tarea eliminada exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Tarea no encontrada</response>
        [HttpDelete("{taskId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTask([FromRoute] int taskId)
            => await HandleResponseHelper.HandleResponse(
                () => _taskUseCase.DeleteTask(taskId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
    }
}