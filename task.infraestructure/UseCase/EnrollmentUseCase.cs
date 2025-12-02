using task.core.DTOs.Response;
using task.core.DTOs.Enrollments;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class EnrollmentUseCase(IEnrollmentRepository enrollmentRepository, ILogService logService) : IEnrollmentUseCase
    {
        private readonly IEnrollmentRepository _enrollmentRepository = enrollmentRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> EnrollStudent(EnrollStudentDTO enrollment)
        {
            try
            {
                return await _enrollmentRepository.EnrollStudent(enrollment);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetAvailableSubjects(int studentId)
        {
            try
            {
                return await _enrollmentRepository.GetAvailableSubjects(studentId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetStudentEnrollments(int studentId)
        {
            try
            {
                return await _enrollmentRepository.GetStudentEnrollments(studentId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> CancelEnrollment(int enrollmentId, int studentId)
        {
            try
            {
                return await _enrollmentRepository.CancelEnrollment(enrollmentId, studentId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetClassmates(int studentId, int subjectId)
        {
            try
            {
                return await _enrollmentRepository.GetClassmates(studentId, subjectId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetAllEnrollments(GetFilterEnrollmentsDTO filters)
        {
            try
            {
                return await _enrollmentRepository.GetAllEnrollments(filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetStudentsBySubject(int subjectId)
        {
            try
            {
                return await _enrollmentRepository.GetStudentsBySubject(subjectId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}