using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.ParticipateMeeting
{
    public class ParticipateMeetingFactory : IDomainFactory<Domain.ParticipateMeeting>
    {
        public Domain.ParticipateMeeting CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.ParticipateMeeting
            {
                IdMeeting = reader.GetInt32(reader.GetOrdinal(ParticipateMeetingRepository.ColIdMeeting)),
                IdTeacher = reader.GetInt32(reader.GetOrdinal(ParticipateMeetingRepository.ColIdTeacher)),
                DateMeeting = reader.GetDateTime(reader.GetOrdinal(ParticipateMeetingRepository.ColDate))
            };
        }
    }
}