using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Note
{
    public partial class NoteRepository : EntityRepository<Domain.Note>
    {
        public NoteRepository(NoteFactory factory) : base(factory)
        {
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
            command.Parameters.AddWithValue("@" + ColDateNote, t.DateNote);
            command.Parameters.AddWithValue("@" + ColMessage, t.Message);

            t.IdNote = (int) command.ExecuteScalar();
            
            return t;
        }

        public override bool Update(int id, Domain.Note t)
        {
            throw new NotImplementedException();
        }
    }
}