using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Students;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;
using WMSGlobal.Infrastructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class StudentUseCase(IStudentRepository studentRepository, ILogService logService) : IStudentUseCase
    {
        private readonly IStudentRepository _studentRepository = studentRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> CreateStudent(CreateStudentDTO student)
        {
            try
            {
                var (passwordHashed, salt) = PasswordHashHelper.HashPassword(student.PasswordHashUser);
                student.PasswordHashUser = passwordHashed;
                student.PasswordSaltUser = salt;

                return await _studentRepository.CreateStudent(student);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> UpdateStudent(UpdateStudentDTO student)
        {
            try
            {
                return await _studentRepository.UpdateStudent(student);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> DeleteStudent(int studentId)
        {
            try
            {
                return await _studentRepository.DeleteStudent(studentId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetStudentById(int studentId)
        {
            try
            {
                return await _studentRepository.GetStudentById(studentId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetListStudents(PaginatorDTO? paginator, GetFilterStudentsDTO filters)
        {
            try
            {
                return await _studentRepository.GetListStudents(paginator, filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}