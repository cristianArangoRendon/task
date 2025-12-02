using task.core.DTOs.Response;
using task.core.DTOs.Professors;

namespace task.core.Interfaces.UseCases
{
    public interface IProfessorUseCase
    {
        Task<ResponseDTO> CreateProfessor(CreateProfessorDTO professor);
        Task<ResponseDTO> UpdateProfessor(UpdateProfessorDTO professor);
        Task<ResponseDTO> DeleteProfessor(int professorId);
        Task<ResponseDTO> GetProfessorById(int professorId);
        Task<ResponseDTO> GetListProfessors(GetFilterProfessorsDTO filters);
        Task<ResponseDTO> GetProfessorSubjects(int professorId);
    }
}