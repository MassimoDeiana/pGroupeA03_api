using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public partial class InterrogationRepository : EntityRepository<Domain.Interrogation>
    {
        public InterrogationRepository(InterrogationFactory factory) : base(factory)
        {
        }

        public override Domain.Interrogation Create(Domain.Interrogation t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = ReqCreate
            };

            command.Parameters.AddWithValue("@" + ColIdLesson, t.IdLesson);
            command.Parameters.AddWithValue("@" + ColSubject, t.Subject);
            command.Parameters.AddWithValue("@" + ColTotal, t.Total);

            t.IdInterro = (int) command.ExecuteScalar();

            return t;
        }
    }
}