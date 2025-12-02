using task.core.DTOs.Response;
using task.core.DTOs.Subjects;

namespace task.core.Interfaces.UseCases
{
    public interface ISubjectUseCase
    {
        Task<ResponseDTO> CreateSubject(CreateSubjectDTO subject);
        Task<ResponseDTO> UpdateSubject(UpdateSubjectDTO subject);
        Task<ResponseDTO> DeleteSubject(int subjectId);
        Task<ResponseDTO> GetSubjectById(int subjectId);
        Task<ResponseDTO> GetListSubjects(GetFilterSubjectsDTO filters);
    }
}