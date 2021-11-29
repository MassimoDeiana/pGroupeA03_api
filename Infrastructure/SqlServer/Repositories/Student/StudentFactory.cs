using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public class StudentFactory : IDomainFactory<Domain.Student>

    {
        public Domain.Student CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Student
            {
                IdStudent = reader.GetInt32(reader.GetOrdinal(StudentRepository.ColId)),
                Name = reader.GetString(reader.GetOrdinal(StudentRepository.ColName)),
                FirstName = reader.GetString(reader.GetOrdinal(StudentRepository.ColFirstname)),
                BirthDate = reader.GetDateTime(reader.GetOrdinal(StudentRepository.ColBirthdate)),
                Mail = reader.GetString(reader.GetOrdinal(StudentRepository.ColMail)),
                IdClass = reader.GetInt32(reader.GetOrdinal(StudentRepository.ColIdClass))
            };
        }
    }
}