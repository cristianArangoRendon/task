using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Enrollments;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class EnrollmentsController(ILogService logService, IEnrollmentUseCase useCase) : ControllerBase
    {
        private readonly IEnrollmentUseCase _enrollmentUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Inscribir a un estudiante en una materia
        /// </summary>
        /// <remarks>
        /// Inscribe a un estudiante en una materia, asignando automáticamente un profesor disponible.
        /// Valida que el estudiante no tenga más de 3 materias y que no repita profesor.
        /// </remarks>
        /// <response code="200">Inscripción exitosa</response>
        /// <response code="400">Datos inválidos o restricciones no cumplidas</response>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EnrollStudent([FromBody] EnrollStudentDTO enrollmentDTO)
            => await HandleResponseHelper.HandleResponse(
                () => _enrollmentUseCase.EnrollStudent(enrollmentDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener materias disponibles para un estudiante
        /// </summary>
        /// <remarks>
        /// Retorna las materias en las que el estudiante puede inscribirse,
        /// excluyendo aquellas donde solo hay profesores con los que ya tiene clases.
        /// </remarks>
        /// <param name="studentId">ID del estudiante</param>
        /// <response code="200">Lista de materias disponibles</response>
        [HttpGet("available-subjects/{studentId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailableSubjects([FromRoute] int studentId)
            => await HandleResponseHelper.HandleResponse(
                () => _enrollmentUseCase.GetAvailableSubjects(studentId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener inscripciones de un estudiante
        /// </summary>
        /// <remarks>
        /// Retorna todas las materias en las que está inscrito el estudiante
        /// con información del profesor asignado y resumen de créditos.
        /// </remarks>
        /// <param name="studentId">ID del estudiante</param>
        /// <response code="200">Lista de inscripciones del estudiante</response>
        [HttpGet("student/{studentId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStudentEnrollments([FromRoute] int studentId)
            => await HandleResponseHelper.HandleResponse(
                () => _enrollmentUseCase.GetStudentEnrollments(studentId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Cancelar una inscripción
        /// </summary>
        /// <remarks>
        /// Cancela la inscripción de un estudiante en una materia (borrado lógico).
        /// </remarks>
        /// <param name="enrollmentId">ID de la inscripción</param>
        /// <param name="studentId">ID del estudiante (validación de seguridad)</param>
        /// <response code="200">Inscripción cancelada exitosamente</response>
        /// <response code="404">Inscripción no encontrada</response>
        [HttpDelete("{enrollmentId:int}/student/{studentId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelEnrollment(
            [FromRoute] int enrollmentId,
            [FromRoute] int studentId)
            => await HandleResponseHelper.HandleResponse(
                () => _enrollmentUseCase.CancelEnrollment(enrollmentId, studentId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener compañeros de clase
        /// </summary>
        /// <remarks>
        /// Retorna la lista de estudiantes inscritos en la misma materia.
        /// Solo muestra el nombre de los compañeros (requerimiento #9).
        /// </remarks>
        /// <param name="studentId">ID del estudiante</param>
        /// <param name="subjectId">ID de la materia</param>
        /// <response code="200">Lista de compañeros de clase</response>
        /// <response code="404">Estudiante no inscrito en la materia</response>
        [HttpGet("classmates/student/{studentId:int}/subject/{subjectId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClassmates(
            [FromRoute] int studentId,
            [FromRoute] int subjectId)
            => await HandleResponseHelper.HandleResponse(
                () => _enrollmentUseCase.GetClassmates(studentId, subjectId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener todas las inscripciones (Administrador)
        /// </summary>
        /// <remarks>
        /// Retorna todas las inscripciones activas con filtros opcionales.
        /// Para uso administrativo.
        /// </remarks>
        /// <response code="200">Lista de inscripciones</response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEnrollments([FromQuery] GetFilterEnrollmentsDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _enrollmentUseCase.GetAllEnrollments(filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener estudiantes por materia
        /// </summary>
        /// <remarks>
        /// Retorna todos los estudiantes inscritos en una materia específica
        /// con sus profesores asignados (requerimiento #8 - ver otros estudiantes).
        /// </remarks>
        /// <param name="subjectId">ID de la materia</param>
        /// <response code="200">Lista de estudiantes en la materia</response>
        [HttpGet("subject/{subjectId:int}/students")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStudentsBySubject([FromRoute] int subjectId)
            => await HandleResponseHelper.HandleResponse(
                () => _enrollmentUseCase.GetStudentsBySubject(subjectId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
    }
}