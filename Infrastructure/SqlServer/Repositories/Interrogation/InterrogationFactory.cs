using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public class InterrogationFactory : IDomainFactory<Domain.Interrogation>
    {
        public Domain.Interrogation CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Interrogation
            {
                IdInterro = reader.GetInt32(reader.GetOrdinal(InterrogationRepository.ColId)),
                IdTeacher = reader.GetInt32(reader.GetOrdinal(InterrogationRepository.ColIdTeacher)),
                IdLesson = reader.GetInt32(reader.GetOrdinal(InterrogationRepository.ColIdLesson)),
                Subject = reader.GetString(reader.GetOrdinal(InterrogationRepository.ColSubject)),
                Total = reader.GetInt32(reader.GetOrdinal(InterrogationRepository.ColTotal))
            };
        }
    }
}