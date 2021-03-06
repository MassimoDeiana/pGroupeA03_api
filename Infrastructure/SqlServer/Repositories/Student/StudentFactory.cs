using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public class StudentFactory : IDomainFactory<Domain.Student>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>Student</returns></summary>
         */
        public Domain.Student CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Student
            {
                IdStudent = reader.GetInt32(reader.GetOrdinal(StudentRepository.ColId)),
                Name = reader.GetString(reader.GetOrdinal(StudentRepository.ColName)),
                FirstName = reader.GetString(reader.GetOrdinal(StudentRepository.ColFirstname)),
                BirthDate = reader.GetDateTime(reader.GetOrdinal(StudentRepository.ColBirthdate)),
                Mail = reader.GetString(reader.GetOrdinal(StudentRepository.ColMail)),
                Password = reader.GetString(reader.GetOrdinal(StudentRepository.ColPassword)),
                IdClass = reader.GetInt32(reader.GetOrdinal(StudentRepository.ColIdClass))
            };
        }
    }
}