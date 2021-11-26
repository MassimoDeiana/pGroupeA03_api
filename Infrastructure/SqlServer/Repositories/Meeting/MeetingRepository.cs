using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public partial class MeetingRepository : EntityRepository<Domain.Meeting>
    {
        public MeetingRepository(MeetingFactory factory) : base(factory)
        {
        }

        public override Domain.Meeting Create(Domain.Meeting t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            
            command.Parameters.AddWithValue("@" + ColSubject, t.Subject);
            

            t.IdMeeting = (int) command.ExecuteScalar();

            return t;
        }

        public override bool Update(int id, Domain.Meeting t)
        {
            throw new NotImplementedException();
        }
    }
}