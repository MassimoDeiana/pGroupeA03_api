using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Result
{
    public class ResultFactory : IDomainFactory<Domain.ResultReport>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>ResultReport</returns></summary>
         */
        public Domain.ResultReport CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.ResultReport
            {
                IdStudent = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColIdStudent)),
                IdInterro = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColIdInterro)),
                Result = reader.GetDouble(reader.GetOrdinal(ResultRepository.ColResult)),
                Total = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColTotal)),
                IdLesson = reader.GetInt32(reader.GetOrdinal(ResultRepository.ColIdLesson)),
                Message = reader.GetString(reader.GetOrdinal(ResultRepository.ColMessage))
                
            };
        }
    }
}