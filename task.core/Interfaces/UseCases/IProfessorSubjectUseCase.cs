using task.core.DTOs.Response;
using task.core.DTOs.ProfessorSubjects;

namespace task.core.Interfaces.UseCases
{
    public interface IProfessorSubjectUseCase
    {
        Task<ResponseDTO> AssignSubjectToProfessor(AssignSubjectDTO assignment);
        Task<ResponseDTO> UnassignSubjectFromProfessor(int professorSubjectId);
        Task<ResponseDTO> GetAllProfessorSubjects(GetFilterProfessorSubjectsDTO filters);
        Task<ResponseDTO> GetAvailableSubjectsForProfessor(int professorId);
        Task<ResponseDTO> GetAvailableProfessorsForSubject(int subjectId);
    }
}