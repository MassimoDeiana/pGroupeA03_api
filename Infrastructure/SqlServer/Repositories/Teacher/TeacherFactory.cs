using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Teacher
{
    public class TeacherFactory : IDomainFactory<Domain.Teacher>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>Teacher</returns></summary>
         */
        public Domain.Teacher CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Teacher
            {
                IdTeacher = reader.GetInt32(reader.GetOrdinal(TeacherRepository.ColId)),
                Name = reader.GetString(reader.GetOrdinal(TeacherRepository.ColName)),
                FirstName = reader.GetString(reader.GetOrdinal(TeacherRepository.ColFirstName)),
                BirthDate = reader.GetDateTime(reader.GetOrdinal(TeacherRepository.ColBirthDate)),
                Mail = reader.GetString(reader.GetOrdinal(TeacherRepository.ColMail)),
                Password = reader.GetString(reader.GetOrdinal(TeacherRepository.ColPassword))
            };    
        }
    }
}