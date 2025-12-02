using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.ProfessorSubjects;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]

    public class ProfessorSubjectsController(ILogService logService, IProfessorSubjectUseCase useCase) : ControllerBase
    {
        private readonly IProfessorSubjectUseCase _professorSubjectUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Asignar una materia a un profesor
        /// </summary>
        /// <remarks>
        /// Asigna una materia a un profesor. Valida que el profesor no tenga más de 2 materias.
        /// </remarks>
        /// <response code="200">Materia asignada exitosamente</response>
        /// <response code="400">Datos inválidos o restricciones no cumplidas</response>
        [HttpPost("assign")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignSubjectToProfessor([FromBody] AssignSubjectDTO assignSubjectDTO)
            => await HandleResponseHelper.HandleResponse(
                () => _professorSubjectUseCase.AssignSubjectToProfessor(assignSubjectDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Desasignar una materia de un profesor
        /// </summary>
        /// <remarks>
        /// Elimina la asignación de una materia a un profesor (borrado lógico)
        /// </remarks>
        /// <param name="professorSubjectId">ID de la asignación</param>
        /// <response code="200">Materia desasignada exitosamente</response>
        /// <response code="400">No se puede desasignar (hay estudiantes inscritos)</response>
        /// <response code="404">Asignación no encontrada</response>
        [HttpDelete("{professorSubjectId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UnassignSubjectFromProfessor([FromRoute] int professorSubjectId)
            => await HandleResponseHelper.HandleResponse(
                () => _professorSubjectUseCase.UnassignSubjectFromProfessor(professorSubjectId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener todas las asignaciones de profesores y materias
        /// </summary>
        /// <remarks>
        /// Retorna todas las asignaciones activas con filtros opcionales por profesor o materia
        /// </remarks>
        /// <response code="200">Lista de asignaciones obtenida exitosamente</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProfessorSubjects([FromQuery] GetFilterProfessorSubjectsDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _professorSubjectUseCase.GetAllProfessorSubjects(filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener materias disponibles para asignar a un profesor
        /// </summary>
        /// <remarks>
        /// Retorna las materias que pueden ser asignadas a un profesor específico
        /// </remarks>
        /// <param name="professorId">ID del profesor</param>
        /// <response code="200">Lista de materias disponibles</response>
        [HttpGet("available-subjects/{professorId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailableSubjectsForProfessor([FromRoute] int professorId)
            => await HandleResponseHelper.HandleResponse(
                () => _professorSubjectUseCase.GetAvailableSubjectsForProfessor(professorId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener profesores disponibles para una materia
        /// </summary>
        /// <remarks>
        /// Retorna los profesores que pueden ser asignados a una materia específica
        /// </remarks>
        /// <param name="subjectId">ID de la materia</param>
        /// <response code="200">Lista de profesores disponibles</response>
        [HttpGet("available-professors/{subjectId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailableProfessorsForSubject([FromRoute] int subjectId)
            => await HandleResponseHelper.HandleResponse(
                () => _professorSubjectUseCase.GetAvailableProfessorsForSubject(subjectId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
    }
}