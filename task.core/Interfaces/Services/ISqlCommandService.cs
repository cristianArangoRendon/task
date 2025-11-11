using System.Data.SqlClient;

namespace task.core.Interfaces.Services
{
    public interface ISqlCommandService
    {
        void AddParameters<T>(SqlCommand command, T parameters);
    }
}
