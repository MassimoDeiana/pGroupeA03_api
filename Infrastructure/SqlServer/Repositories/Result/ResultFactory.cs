using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Result
{
    public class ResultFactory : IDomainFactory<Domain.ResultReport>
    {
        public Domain.ResultReport CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.ResultReport
            {
                IdStudent = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColIdStudent)),
                IdInterro = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColIdInterro)),
                Result = reader.GetDouble(reader.GetOrdinal(ResultRepository.ColResult)),
                Total = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColTotal)),
                IdLesson = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColIdLesson))
                
            };
        }
    }
}