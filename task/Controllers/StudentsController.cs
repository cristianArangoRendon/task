using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Paginator;
using task.core.DTOs.Students;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]

    public class StudentsController(ILogService logService, IStudentUseCase useCase) : ControllerBase
    {
        private readonly IStudentUseCase _studentUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Obtener lista de estudiantes con filtros y paginación
        /// </summary>
        /// <remarks>
        /// Permite filtrar estudiantes por término de búsqueda y obtener resultados paginados
        /// </remarks>
        /// <response code="200">Lista de estudiantes obtenida exitosamente</response>
        /// <response code="401">No autorizado - Token inválido o expirado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudents(
            [FromQuery] PaginatorDTO? paginator,
            [FromQuery] GetFilterStudentsDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _studentUseCase.GetListStudents(paginator, filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener un estudiante por ID
        /// </summary>
        /// <remarks>
        /// Obtiene la información detallada de un estudiante específico incluyendo créditos y materias inscritas
        /// </remarks>
        /// <param name="studentId">ID del estudiante</param>
        /// <response code="200">Estudiante obtenido exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Estudiante no encontrado</response>
        [HttpGet("{studentId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById([FromRoute] int studentId)
            => await HandleResponseHelper.HandleResponse(
                () => _studentUseCase.GetStudentById(studentId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Crear un nuevo estudiante
        /// </summary>
        /// <remarks>
        /// Crea un nuevo estudiante en el sistema con la información proporcionada
        /// </remarks>
        /// <response code="201">Estudiante creado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="401">No autorizado</response>
        /// <response code="409">El correo electrónico ya existe</response>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO createStudentDTO)
            => await HandleResponseHelper.HandleResponse(
                () => _studentUseCase.CreateStudent(createStudentDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Actualizar un estudiante existente
        /// </summary>
        /// <remarks>
        /// Actualiza la información de un estudiante existente
        /// </remarks>
        /// <param name="studentId">ID del estudiante a actualizar</param>
        /// <param name="updateStudentDTO">Datos actualizados del estudiante</param>
        /// <response code="200">Estudiante actualizado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Estudiante no encontrado</response>
        [HttpPut("{studentId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(
            [FromRoute] int studentId,
            [FromBody] UpdateStudentDTO updateStudentDTO)
        {
            updateStudentDTO.StudentId = studentId;
            return await HandleResponseHelper.HandleResponse(
                () => _studentUseCase.UpdateStudent(updateStudentDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
        }

        /// <summary>
        /// Eliminar un estudiante (borrado lógico)
        /// </summary>
        /// <remarks>
        /// Realiza un borrado lógico del estudiante y sus inscripciones, marcándolos como inactivos
        /// </remarks>
        /// <param name="studentId">ID del estudiante a eliminar</param>
        /// <response code="200">Estudiante eliminado exitosamente</response>
        /// <response code="401">No autorizado</response>
        /// <response code="404">Estudiante no encontrado</response>
        [HttpDelete("{studentId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int studentId)
            => await HandleResponseHelper.HandleResponse(
                () => _studentUseCase.DeleteStudent(studentId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
    }
}