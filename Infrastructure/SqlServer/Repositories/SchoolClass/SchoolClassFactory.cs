using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.SchoolClass
{
    public class SchoolClassFactory : IDomainFactory<Domain.SchoolClass>
    {
        public Domain.SchoolClass CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.SchoolClass
            {
                Id = reader.GetInt32(reader.GetOrdinal(SchoolClassRepository.ColId)),
                Name = reader.GetString(reader.GetOrdinal(SchoolClassRepository.ColName)),
                Year = reader.GetByte(reader.GetOrdinal(SchoolClassRepository.ColYear)),
                NbStudents = reader.GetInt32(reader.GetOrdinal(SchoolClassRepository.ColNbStudents))
            };
        }
    }
}