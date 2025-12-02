using task.core.DTOs.Paginator;
using task.core.DTOs.Response;
using task.core.DTOs.Students;
using task.core.Interfaces.Repositories;
using task.core.Interfaces.Services;
using task.infraestructure.Helpers;
using task.Infrastructure.Helpers;

namespace task.infraestructure.Repositories
{
    public class StudentRepository(IExecuteStoreProcedureService service) : IStudentRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService = service;

        public async Task<ResponseDTO> CreateStudent(CreateStudentDTO student)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.CreateStudent",
                ObjectExtensionsHelper.ToObject<CreateStudentDTO>(student)
            );
        }

        public async Task<ResponseDTO> UpdateStudent(UpdateStudentDTO student)
        {
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.UpdateStudent",
                ObjectExtensionsHelper.ToObject<UpdateStudentDTO>(student)
            );
        }

        public async Task<ResponseDTO> DeleteStudent(int studentId)
        {
            object obj = new
            {
                StudentId = studentId
            };
            return await _executeStoreProcedureService.ExecuteStoredProcedure(
                "dbo.DeleteStudent",
                obj
            );
        }

        public async Task<ResponseDTO> GetStudentById(int studentId)
        {
            object obj = new
            {
                StudentId = studentId
            };
            return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure(
                "dbo.GetStudentById",
                obj,
                MapToObjHelper.MapToObj<StudentMapDataByIdDTO>
            );
        }

        public async Task<ResponseDTO> GetListStudents(PaginatorDTO? paginator, GetFilterStudentsDTO filters)
        {
            return await _executeStoreProcedureService.ExecuteTableStoredProcedure(
                "dbo.GetListStudents",
                ObjectExtensionsHelper.ToObject<GetFilterStudentsDTO>(filters),
                MapToListHelper.MapToList<StudentMapDataListDTO>
            );
        }
    }
}