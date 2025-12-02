using task.core.DTOs.Professor;
using task.core.DTOs.Professors;
using task.core.DTOs.Response;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class ProfessorRepository(IExecuteStoreProcedureService service) : IProfessorRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> CreateProfessor(CreateProfessorDTO professor)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.CreateProfessor",
                ObjectExtensionsHelper.ToObject<CreateProfessorDTO>(professor)
            );
        }

        public async Task<ResponseDTO> UpdateProfessor(UpdateProfessorDTO professor)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.UpdateProfessor",
                ObjectExtensionsHelper.ToObject<UpdateProfessorDTO>(professor)
            );
        }

        public async Task<ResponseDTO> DeleteProfessor(int professorId)
        {
            object obj = new
            {
                ProfessorId = professorId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.DeleteProfessor",
                obj
            );
        }

        public async Task<ResponseDTO> GetProfessorById(int professorId)
        {
            object obj = new
            {
                ProfessorId = professorId
            };
            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetProfessorById",
                obj,
                MapToObjHelper.MapToObj<ProfessorMapDataByIdDTO>
            );
        }

        public async Task<ResponseDTO> GetListProfessors(GetFilterProfessorsDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetListProfessors",
                ObjectExtensionsHelper.ToObject<GetFilterProfessorsDTO>(filters),
                MapToListHelper.MapToList<ProfessorMapDataListDTO>
            );
        }

        public async Task<ResponseDTO> GetProfessorSubjects(int professorId)
        {
            object obj = new
            {
                ProfessorId = professorId
            };
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetProfessorSubjects",
                obj,
                MapToListHelper.MapToList<ProfessorSubjectDTO>
            );
        }
    }
}