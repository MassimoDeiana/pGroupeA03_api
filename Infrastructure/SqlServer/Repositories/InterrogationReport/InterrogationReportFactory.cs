using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.InterrogationReport
{
    public class InterrogationReportFactory : IDomainFactory<Domain.InterrogationReport>
    {
        public Domain.InterrogationReport CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.InterrogationReport
            {
                IdInterro = reader.GetInt32(reader.GetOrdinal(InterrogationReportRepository.ColIdInterro)),
                IdStudent = reader.GetInt32(reader.GetOrdinal(InterrogationReportRepository.ColIdStudent)),
                Name = reader.GetString(reader.GetOrdinal(InterrogationReportRepository.ColName)),
                FirstName = reader.GetString(reader.GetOrdinal(InterrogationReportRepository.ColFirstName)),
                Result = reader.GetDouble(reader.GetOrdinal(InterrogationReportRepository.ColResult)),
                Total = reader.GetInt32(reader.GetOrdinal(InterrogationReportRepository.ColTotal)),
                Message = reader.GetString(reader.GetOrdinal(InterrogationReportRepository.ColMessage))
            };
        }
    }
}