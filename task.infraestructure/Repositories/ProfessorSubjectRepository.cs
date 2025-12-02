using task.core.DTOs.Response;
using task.core.DTOs.ProfessorSubjects;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class ProfessorSubjectRepository(IExecuteStoreProcedureService service) : IProfessorSubjectRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> AssignSubjectToProfessor(AssignSubjectDTO assignment)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.AssignSubjectToProfessor",
                ObjectExtensionsHelper.ToObject<AssignSubjectDTO>(assignment)
            );
        }

        public async Task<ResponseDTO> UnassignSubjectFromProfessor(int professorSubjectId)
        {
            object obj = new
            {
                ProfessorSubjectId = professorSubjectId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.UnassignSubjectFromProfessor",
                obj
            );
        }

        public async Task<ResponseDTO> GetAllProfessorSubjects(GetFilterProfessorSubjectsDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetAllProfessorSubjects",
                ObjectExtensionsHelper.ToObject<GetFilterProfessorSubjectsDTO>(filters),
                MapToListHelper.MapToList<ProfessorSubjectMapDataDTO>
            );
        }

        public async Task<ResponseDTO> GetAvailableSubjectsForProfessor(int professorId)
        {
            object obj = new
            {
                ProfessorId = professorId
            };
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetAvailableSubjectsForProfessor",
                obj,
                MapToListHelper.MapToList<AvailableSubjectForProfessorDTO>
            );
        }

        public async Task<ResponseDTO> GetAvailableProfessorsForSubject(int subjectId)
        {
            object obj = new
            {
                SubjectId = subjectId
            };
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetAvailableProfessorsForSubject",
                obj,
                MapToListHelper.MapToList<AvailableProfessorForSubjectDTO>
            );
        }
    }
}