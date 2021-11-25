using System.Data.SqlClient;

namespace Infrastructure.SqlServer
{
    public class Database
    {
        private const string ConnectionString = "Server=MSI;Database=dbgroupeA03;Integrated Security=SSPI";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        } 
    }
}