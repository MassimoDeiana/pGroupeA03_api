using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.ParticipateMeeting
{
    public class ParticipateMeetingFactory : IDomainFactory<Domain.ParticipateMeeting>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>ParticipateMeeting</returns></summary>
         */
        public Domain.ParticipateMeeting CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.ParticipateMeeting
            {
                IdMeeting = reader.GetInt32(reader.GetOrdinal(ParticipateMeetingRepository.ColIdMeeting)),
                IdTeacher = reader.GetInt32(reader.GetOrdinal(ParticipateMeetingRepository.ColIdTeacher)),
            };
        }
    }
}