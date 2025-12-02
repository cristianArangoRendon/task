using task.core.DTOs.Response;
using task.core.DTOs.Professors;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class ProfessorUseCase(IProfessorRepository professorRepository, ILogService logService) : IProfessorUseCase
    {
        private readonly IProfessorRepository _professorRepository = professorRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> CreateProfessor(CreateProfessorDTO professor)
        {
            try
            {
                return await _professorRepository.CreateProfessor(professor);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> UpdateProfessor(UpdateProfessorDTO professor)
        {
            try
            {
                return await _professorRepository.UpdateProfessor(professor);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> DeleteProfessor(int professorId)
        {
            try
            {
                return await _professorRepository.DeleteProfessor(professorId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetProfessorById(int professorId)
        {
            try
            {
                return await _professorRepository.GetProfessorById(professorId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetListProfessors(GetFilterProfessorsDTO filters)
        {
            try
            {
                return await _professorRepository.GetListProfessors(filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetProfessorSubjects(int professorId)
        {
            try
            {
                return await _professorRepository.GetProfessorSubjects(professorId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}