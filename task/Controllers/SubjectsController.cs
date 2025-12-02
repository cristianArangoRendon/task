using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using task.core.DTOs.Subjects;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace WMSGlobal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]

    public class SubjectsController(ILogService logService, ISubjectUseCase useCase) : ControllerBase
    {
        private readonly ISubjectUseCase _subjectUseCase = useCase;
        private readonly ILogService _logService = logService;

        /// <summary>
        /// Obtener lista de materias
        /// </summary>
        /// <remarks>
        /// Retorna todas las materias disponibles con sus créditos
        /// </remarks>
        /// <response code="200">Lista de materias obtenida exitosamente</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubjects([FromQuery] GetFilterSubjectsDTO filters)
            => await HandleResponseHelper.HandleResponse(
                () => _subjectUseCase.GetListSubjects(filters),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Obtener materia por ID
        /// </summary>
        [HttpGet("{subjectId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSubjectById([FromRoute] int subjectId)
            => await HandleResponseHelper.HandleResponse(
                () => _subjectUseCase.GetSubjectById(subjectId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Crear una nueva materia
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectDTO createSubjectDTO)
            => await HandleResponseHelper.HandleResponse(
                () => _subjectUseCase.CreateSubject(createSubjectDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );

        /// <summary>
        /// Actualizar una materia
        /// </summary>
        [HttpPut("{subjectId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSubject(
            [FromRoute] int subjectId,
            [FromBody] UpdateSubjectDTO updateSubjectDTO)
        {
            updateSubjectDTO.SubjectId = subjectId;
            return await HandleResponseHelper.HandleResponse(
                () => _subjectUseCase.UpdateSubject(updateSubjectDTO),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
        }

        /// <summary>
        /// Eliminar una materia
        /// </summary>
        [HttpDelete("{subjectId:int}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSubject([FromRoute] int subjectId)
            => await HandleResponseHelper.HandleResponse(
                () => _subjectUseCase.DeleteSubject(subjectId),
                _logService,
                MethodBase.GetCurrentMethod()?.Name ?? string.Empty
            );
    }
}