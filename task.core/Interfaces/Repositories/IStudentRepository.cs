using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Students;

namespace task.core.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<ResponseDTO> CreateStudent(CreateStudentDTO student);
        Task<ResponseDTO> UpdateStudent(UpdateStudentDTO student);
        Task<ResponseDTO> DeleteStudent(int studentId);
        Task<ResponseDTO> GetStudentById(int studentId);
        Task<ResponseDTO> GetListStudents(PaginatorDTO? paginator, GetFilterStudentsDTO filters);
    }
}