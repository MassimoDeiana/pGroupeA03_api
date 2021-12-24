using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public class MeetingFactory : IDomainFactory<Domain.Meeting>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>Meeting</returns></summary>
         */
        public Domain.Meeting CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Meeting
            {
                IdMeeting = reader.GetInt32(reader.GetOrdinal(MeetingRepository.ColId)),
                Subject = reader.GetString(reader.GetOrdinal(MeetingRepository.ColSubject)),
                StartTime = reader.GetDateTime(reader.GetOrdinal(MeetingRepository.ColStart)),
                EndTime = reader.GetDateTime(reader.GetOrdinal(MeetingRepository.ColEnd))
            };    
        }
    }
}