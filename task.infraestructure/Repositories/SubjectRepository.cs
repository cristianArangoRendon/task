using task.core.DTOs.Response;
using task.core.DTOs.Subjects;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class SubjectRepository(IExecuteStoreProcedureService service) : ISubjectRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> CreateSubject(CreateSubjectDTO subject)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.CreateSubject",
                ObjectExtensionsHelper.ToObject<CreateSubjectDTO>(subject)
            );
        }

        public async Task<ResponseDTO> UpdateSubject(UpdateSubjectDTO subject)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.UpdateSubject",
                ObjectExtensionsHelper.ToObject<UpdateSubjectDTO>(subject)
            );
        }

        public async Task<ResponseDTO> DeleteSubject(int subjectId)
        {
            object obj = new
            {
                SubjectId = subjectId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.DeleteSubject",
                obj
            );
        }

        public async Task<ResponseDTO> GetSubjectById(int subjectId)
        {
            object obj = new
            {
                SubjectId = subjectId
            };
            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetSubjectById",
                obj,
                MapToObjHelper.MapToObj<SubjectMapDataDTO>
            );
        }

        public async Task<ResponseDTO> GetListSubjects(GetFilterSubjectsDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetListSubjects",
                ObjectExtensionsHelper.ToObject<GetFilterSubjectsDTO>(filters),
                MapToListHelper.MapToList<SubjectMapDataDTO>
            );
        }
    }
}