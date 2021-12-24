using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Admin
{
    public class AdminFactory : IDomainFactory<Domain.Admin>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>Admin</returns></summary>
         */
        public Domain.Admin CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Admin
            {
                IdAdmin = reader.GetInt32(reader.GetOrdinal(AdminRepository.ColId)),
                Mail = reader.GetString(reader.GetOrdinal(AdminRepository.ColMail)),
                Password = reader.GetString(reader.GetOrdinal(AdminRepository.ColPassword))
            };
        }
    }
}