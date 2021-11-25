using System.Data.SqlClient;

namespace Infrastructure.SqlServer.Utils
{
    public interface IDomainFactory<out T>
    {
        T CreateFromSqlReader(SqlDataReader reader);
    }
}