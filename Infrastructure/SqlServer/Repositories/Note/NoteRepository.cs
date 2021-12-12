using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Note
{
    public partial class NoteRepository : EntityRepository<Domain.Note>, INoteRepository
    {
        private readonly NoteFactory _factory;

        public NoteRepository(NoteFactory factory) : base(factory)
        {
            _factory = factory;
        }

        public override Domain.Note Create(Domain.Note t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            
            command.Parameters.AddWithValue("@" + ColIdTeacher, t.IdTeacher);
            command.Parameters.AddWithValue("@" + ColIdStudent, t.IdStudent);
            command.Parameters.AddWithValue("@" + ColIdInterro, t.IdInterro);
            command.Parameters.AddWithValue("@" + ColDateNote, t.DateNote);
            command.Parameters.AddWithValue("@" + ColResult, t.Result);
            command.Parameters.AddWithValue("@" + ColMessage, t.Message);

            t.IdNote = (int) command.ExecuteScalar();
            
            return t;
        }
        public new List<Domain.Note> GetById(int id)
        {
            var entities = new List<Domain.Note>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = $@"SELECT * FROM {TableName} WHERE {ColIdStudent} = @{ColIdStudent}"
            };

            command.Parameters.AddWithValue("@" + ColIdStudent, id);
            
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                entities.Add(_factory.CreateFromSqlReader(reader));
            }

            return entities;
        }
    }
}
