using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.SchoolClass
{
    public partial class SchoolClassRepository : EntityRepository<Domain.SchoolClass>
    {
        public SchoolClassRepository(SchoolClassFactory factory) : base(factory, "schoolclass")
        {
        }

        /*public override Domain.SchoolClass Create(Domain.SchoolClass t)
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
        }*/
    }
}