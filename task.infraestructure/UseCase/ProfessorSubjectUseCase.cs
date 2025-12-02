using task.core.DTOs.Response;
using task.core.DTOs.ProfessorSubjects;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class ProfessorSubjectUseCase(IProfessorSubjectRepository professorSubjectRepository, ILogService logService) : IProfessorSubjectUseCase
    {
        private readonly IProfessorSubjectRepository _professorSubjectRepository = professorSubjectRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> AssignSubjectToProfessor(AssignSubjectDTO assignment)
        {
            try
            {
                return await _professorSubjectRepository.AssignSubjectToProfessor(assignment);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> UnassignSubjectFromProfessor(int professorSubjectId)
        {
            try
            {
                return await _professorSubjectRepository.UnassignSubjectFromProfessor(professorSubjectId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetAllProfessorSubjects(GetFilterProfessorSubjectsDTO filters)
        {
            try
            {
                return await _professorSubjectRepository.GetAllProfessorSubjects(filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetAvailableSubjectsForProfessor(int professorId)
        {
            try
            {
                return await _professorSubjectRepository.GetAvailableSubjectsForProfessor(professorId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetAvailableProfessorsForSubject(int subjectId)
        {
            try
            {
                return await _professorSubjectRepository.GetAvailableProfessorsForSubject(subjectId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}