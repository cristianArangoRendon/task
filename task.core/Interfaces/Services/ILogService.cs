using task.core.Enum;

namespace task.core.Interfaces.Services
{
    public interface ILogService
    {
        Task SaveLogsMessagesAsync(string messages, LogLevel level = LogLevel.Information);
        Task LogInformationAsync(string message);
        Task LogSuccessAsync(string message);
        Task LogWarningAsync(string message);
        Task LogErrorAsync(string message, Exception? exception = null);
        Task LogCriticalAsync(string message, Exception? exception = null);
        Task LogDebugAsync(string message);
    }
}
