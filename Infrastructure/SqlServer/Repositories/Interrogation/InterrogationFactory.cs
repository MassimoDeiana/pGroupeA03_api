using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public class InterrogationFactory : IDomainFactory<Domain.Interrogation>
    {
        public Domain.Interrogation CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Interrogation
            {
                IdInterro = reader.GetInt32(reader.GetOrdinal(InterrogationRepository.ColId)),
                IdLesson = reader.GetInt32(reader.GetOrdinal(InterrogationRepository.ColIdLesson)),
                Subject = reader.GetString(reader.GetOrdinal(InterrogationRepository.ColSubject)),
                Total = reader.GetInt32(reader.GetOrdinal(InterrogationRepository.ColTotal))
            };
        }
    }
}