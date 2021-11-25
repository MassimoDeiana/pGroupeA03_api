using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Repositories.Teacher;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public partial class MeetingRepository : IMeetingRepository
    {
        private readonly IDomainFactory<Domain.Meeting> _meetingFactory = new MeetingFactory();

        public List<Domain.Meeting> GetAll()
        {
            var meetings = new List<Domain.Meeting>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetAll
            };

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                meetings.Add(_meetingFactory.CreateFromSqlReader(reader));
            }

            return meetings;
        }

        public Domain.Meeting GetById(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetById
            };
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            return reader.Read() ? _meetingFactory.CreateFromSqlReader(reader) : null;
        }
        
        public Domain.Meeting Create(Domain.Meeting meeting)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            
            command.Parameters.AddWithValue("@" + ColSubject, meeting.Subject);
            

            meeting.IdMeeting = (int) command.ExecuteScalar();

            return meeting;
        }

        
        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqDelete
            };

            command.Parameters.AddWithValue("@" + ColId, id);
            return command.ExecuteNonQuery() > 0;
        }
    }
}