using Microsoft.Extensions.Configuration;
using System.Text;
using task.core.Enum;
using task.core.Interfaces.Services;

namespace WMSGlobal.Infrastructure.Services
{
    public class LogsService(IConfiguration configuration) : ILogService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public async Task SaveLogsMessagesAsync(string messages, LogLevel level = LogLevel.Information)
        {
            string filePath = _configuration["PathLogs"] ?? string.Empty;

            if (string.IsNullOrEmpty(filePath))
            {
                throw new InvalidOperationException("PathLogs no está configurado correctamente.");
            }

            await _semaphore.WaitAsync();
            try
            {
                var directoryPath = Path.GetDirectoryName(filePath) ?? string.Empty;

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(filePath) && new FileInfo(filePath).Length > 100 * 1024 * 1024)
                {
                    string backupFilePath = $"{filePath}.{DateTime.Now:yyyyMMddHHmmss}.bak";
                    File.Move(filePath, backupFilePath);
                }

                string logPrefix = GetLogPrefix(level);
                string formattedMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {logPrefix} {messages}";

                await using StreamWriter writer = new(filePath, append: true, Encoding.UTF8);
                await writer.WriteLineAsync(formattedMessage);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task LogInformationAsync(string message)
        {
            await SaveLogsMessagesAsync(message, LogLevel.Information);
        }

        public async Task LogSuccessAsync(string message)
        {
            await SaveLogsMessagesAsync(message, LogLevel.Success);
        }

        public async Task LogWarningAsync(string message)
        {
            await SaveLogsMessagesAsync(message, LogLevel.Warning);
        }

        public async Task LogErrorAsync(string message, Exception? exception = null)
        {
            var fullMessage = exception != null
                ? $"{message} | Exception: {exception.Message} | StackTrace: {exception.StackTrace}"
                : message;

            await SaveLogsMessagesAsync(fullMessage, LogLevel.Error);
        }

        public async Task LogCriticalAsync(string message, Exception? exception = null)
        {
            var fullMessage = exception != null
                ? $"{message} | Exception: {exception.Message} | StackTrace: {exception.StackTrace} | InnerException: {exception.InnerException?.Message}"
                : message;

            await SaveLogsMessagesAsync(fullMessage, LogLevel.Critical);
        }

        public async Task LogDebugAsync(string message)
        {
            await SaveLogsMessagesAsync(message, LogLevel.Debug);
        }

        private static string GetLogPrefix(LogLevel level)
        {
            return level switch
            {
                LogLevel.Information => "[INFO]",
                LogLevel.Success => "[SUCCESS] ✓",
                LogLevel.Warning => "[WARNING] ⚠",
                LogLevel.Error => "[ERROR] ✗",
                LogLevel.Critical => "[CRITICAL] ‼",
                LogLevel.Debug => "[DEBUG] 🔍",
                _ => "[LOG]"
            };
        }
    }
}