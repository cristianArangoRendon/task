using System.Data.SqlClient;
using task.core.DTOs.Response;

namespace task.core.Interfaces.Services
{
    public interface IExecuteStoreProcedureService
    {
        Task<ResponseDTO> ExecuteStoredProcedure(string storedProcedureName, object parameters);
        Task<ResponseDTO> ExecuteDataStoredProcedure<TResult>(string storedProcedureName, object? parameters, Func<SqlDataReader, List<TResult>> mapFunction);
        Task<ResponseDTO> ExecuteSingleObjectStoredProcedure<TResult>(string storedProcedureName, object parameters, Func<SqlDataReader, TResult> mapFunction);
        Task<ResponseDTO> ExecuteTableStoredProcedure<TResult>(string storedProcedureName, object? parameters, Func<SqlDataReader, List<TResult>> mapFunction);
        Task<ResponseDTO> ExecuteJsonStoredProcedure(string storedProcedureName, object parameters);

    }
}
