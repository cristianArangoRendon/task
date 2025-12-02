using task.core.DTOs.Response;
using task.core.DTOs.Enrollments;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class EnrollmentRepository(IExecuteStoreProcedureService service) : IEnrollmentRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> EnrollStudent(EnrollStudentDTO enrollment)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.EnrollStudentInSubject",
                ObjectExtensionsHelper.ToObject<EnrollStudentDTO>(enrollment)
            );
        }

        public async Task<ResponseDTO> GetAvailableSubjects(int studentId)
        {
            object obj = new
            {
                StudentId = studentId
            };
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetAvailableSubjectsForStudent",
                obj,
                MapToListHelper.MapToList<AvailableSubjectForStudentDTO>
            );
        }

        public async Task<ResponseDTO> GetStudentEnrollments(int studentId)
        {
            object obj = new
            {
                StudentId = studentId
            };
            return await _executeStoreProcedureService.ExecuteDataStoredProcedure(
                "dbo.GetStudentEnrollments",
                obj,
                MapToListHelper.MapToList<StudentEnrollmentDTO>
            );
        }

        public async Task<ResponseDTO> CancelEnrollment(int enrollmentId, int studentId)
        {
            object obj = new
            {
                EnrollmentId = enrollmentId,
                StudentId = studentId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.CancelEnrollment",
                obj
            );
        }

        public async Task<ResponseDTO> GetClassmates(int studentId, int subjectId)
        {
            object obj = new
            {
                StudentId = studentId,
                SubjectId = subjectId
            };
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetClassmates",
                obj,
                MapToListHelper.MapToList<ClassmateDTO>
            );
        }

        public async Task<ResponseDTO> GetAllEnrollments(GetFilterEnrollmentsDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetAllEnrollments",
                ObjectExtensionsHelper.ToObject<GetFilterEnrollmentsDTO>(filters),
                MapToListHelper.MapToList<AllEnrollmentDTO>
            );
        }

        public async Task<ResponseDTO> GetStudentsBySubject(int subjectId)
        {
            object obj = new
            {
                SubjectId = subjectId
            };
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetStudentsBySubject",
                obj,
                MapToListHelper.MapToList<StudentsBySubjectDTO>
            );
        }
    }
}