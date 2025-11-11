using System.Data.SqlClient;

namespace task.core.Interfaces.Repositories.DataContext
{
    public interface  IDataContext
    { 
        SqlConnection CreateConnection();
        SqlCommand CreateCommand();
    }
}
