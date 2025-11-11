using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using task.core.Interfaces.Repositories.DataContext;
using task.core.Interfaces.Services;

namespace task.infraestructure.Repositories.DataContext
{
    public class DataContext(IConfiguration configuration, ILogService logService) : IDataContext
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is missing from configuration");
        private readonly ILogService _logService = logService ?? throw new ArgumentNullException(nameof(logService));

        /// <summary>
        /// Creates a new SQL connection. The connection is not opened automatically.
        /// Caller is responsible for disposing the connection (use 'using' statement).
        /// </summary>
        /// <returns>A new SqlConnection instance</returns>
        public SqlConnection CreateConnection()
        {
            try
            {
                return new SqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                _ = _logService.SaveLogsMessagesAsync($"Error creating SQL connection: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Creates a SqlCommand with a new connection attached.
        /// Caller is responsible for disposing both the command and its connection.
        /// </summary>
        /// <returns>A new SqlCommand with connection attached</returns>
        public SqlCommand CreateCommand()
        {
            try
            {
                var connection = CreateConnection();
                return new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text
                };
            }
            catch (Exception ex)
            {
                _ = _logService.SaveLogsMessagesAsync($"Error creating SQL command: {ex.Message}");
                throw;
            }
        }
    }
}
