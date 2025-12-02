using task.core.DTOs.Response;
using task.core.DTOs.Subjects;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.core.Interfaces.UseCases;
using task.infraestructure.Helpers;

namespace task.Infrastructure.UseCases
{
    public class SubjectUseCase(ISubjectRepository subjectRepository, ILogService logService) : ISubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository = subjectRepository;
        private readonly ILogService _logService = logService;

        public async Task<ResponseDTO> CreateSubject(CreateSubjectDTO subject)
        {
            try
            {
                return await _subjectRepository.CreateSubject(subject);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> UpdateSubject(UpdateSubjectDTO subject)
        {
            try
            {
                return await _subjectRepository.UpdateSubject(subject);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> DeleteSubject(int subjectId)
        {
            try
            {
                return await _subjectRepository.DeleteSubject(subjectId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetSubjectById(int subjectId)
        {
            try
            {
                return await _subjectRepository.GetSubjectById(subjectId);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }

        public async Task<ResponseDTO> GetListSubjects(GetFilterSubjectsDTO filters)
        {
            try
            {
                return await _subjectRepository.GetListSubjects(filters);
            }
            catch (Exception ex) when (ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod()?.Name ?? string.Empty, ex) is var response)
            {
                return response;
            }
        }
    }
}