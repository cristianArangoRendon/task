using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Professors;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]

    public class ProfessorsController(ILogService logService, IProfessorUseCase useCase) : ControllerBase
    {
        private readonly IProfessorUseCase _professorUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Obtener lista de profesores
        /// </summary>
        /// <remarks>
        /// Retorna todos los profesores con sus materias asignadas y cantidad de estudiantes
        /// </remarks>
        /// <response code="200">Lista de profesores obtenida exitosamente</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfessors([FromQuery] GetFilterProfessorsDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _professorUseCase.GetListProfessors(filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener profesor por ID
        /// </summary>
        /// <remarks>
        /// Obtiene la información detallada de un profesor incluyendo materias y estudiantes
        /// </remarks>
        /// <param name="professorId">ID del profesor</param>
        /// <response code="200">Profesor obtenido exitosamente</response>
        /// <response code="404">Profesor no encontrado</response>
        [HttpGet("{professorId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProfessorById([FromRoute] int professorId)
            => await HandleResponseHelper.HandleResponse(
                () => _professorUseCase.GetProfessorById(professorId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener materias de un profesor
        /// </summary>
        /// <remarks>
        /// Retorna las materias asignadas a un profesor específico
        /// </remarks>
        /// <param name="professorId">ID del profesor</param>
        /// <response code="200">Materias obtenidas exitosamente</response>
        [HttpGet("{professorId:int}/subjects")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfessorSubjects([FromRoute] int professorId)
            => await HandleResponseHelper.HandleResponse(
                () => _professorUseCase.GetProfessorSubjects(professorId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Crear un nuevo profesor
        /// </summary>
        /// <remarks>
        /// Crea un nuevo profesor en el sistema
        /// </remarks>
        /// <response code="201">Profesor creado exitosamente</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="409">El email ya existe</response>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateProfessor([FromBody] CreateProfessorDTO createProfessorDTO)
            => await HandleResponseHelper.HandleResponse(
                () => _professorUseCase.CreateProfessor(createProfessorDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Actualizar un profesor
        /// </summary>
        /// <remarks>
        /// Actualiza la información de un profesor existente
        /// </remarks>
        /// <param name="professorId">ID del profesor</param>
        /// <param name="updateProfessorDTO">Datos actualizados</param>
        /// <response code="200">Profesor actualizado exitosamente</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="404">Profesor no encontrado</response>
        [HttpPut("{professorId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProfessor(
            [FromRoute] int professorId,
            [FromBody] UpdateProfessorDTO updateProfessorDTO)
        {
            updateProfessorDTO.ProfessorId = professorId;
            return await HandleResponseHelper.HandleResponse(
                () => _professorUseCase.UpdateProfessor(updateProfessorDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
        }

        /// <summary>
        /// Eliminar un profesor
        /// </summary>
        /// <remarks>
        /// Realiza un borrado lógico del profesor y sus asignaciones de materias
        /// </remarks>
        /// <param name="professorId">ID del profesor</param>
        /// <response code="200">Profesor eliminado exitosamente</response>
        /// <response code="400">No se puede eliminar (tiene estudiantes activos)</response>
        /// <response code="404">Profesor no encontrado</response>
        [HttpDelete("{professorId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProfessor([FromRoute] int professorId)
            => await HandleResponseHelper.HandleResponse(
                () => _professorUseCase.DeleteProfessor(professorId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
    }
}