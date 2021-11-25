using System.Data.SqlClient;
using Infrastructure.SqlServer.Repositories.Teacher;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public class MeetingFactory : IDomainFactory<Domain.Meeting>
    {
        public Domain.Meeting CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Meeting
            {
                IdMeeting = reader.GetInt32(reader.GetOrdinal(MeetingRepository.ColId)),
                Subject = reader.GetString(reader.GetOrdinal(MeetingRepository.ColSubject))
               
            };    
        }
    }
}