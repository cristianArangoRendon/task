using task.core.DTOs.Response;
using task.core.DTOs.Enrollments;

namespace task.core.Interfaces.UseCases
{
    public interface IEnrollmentUseCase
    {
        Task<ResponseDTO> EnrollStudent(EnrollStudentDTO enrollment);
        Task<ResponseDTO> GetAvailableSubjects(int studentId);
        Task<ResponseDTO> GetStudentEnrollments(int studentId);
        Task<ResponseDTO> CancelEnrollment(int enrollmentId, int studentId);
        Task<ResponseDTO> GetClassmates(int studentId, int subjectId);
        Task<ResponseDTO> GetAllEnrollments(GetFilterEnrollmentsDTO filters);
        Task<ResponseDTO> GetStudentsBySubject(int subjectId);
    }
}