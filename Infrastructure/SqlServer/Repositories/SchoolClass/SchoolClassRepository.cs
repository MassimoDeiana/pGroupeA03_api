using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.SchoolClass
{
    public partial class SchoolClassRepository : EntityRepository<Domain.SchoolClass>
    {
        public SchoolClassRepository(SchoolClassFactory factory) : base(factory)
        {
        }

        public override Domain.SchoolClass Create(Domain.SchoolClass t)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };

            command.Parameters.AddWithValue("@" + ColName, t.Name);
            command.Parameters.AddWithValue("@" + ColYear, t.Year);
            command.Parameters.AddWithValue("@" + ColNbStudents, t.NbStudents);

            t.Id = (int) command.ExecuteScalar();

            return t;
        }
    }
}