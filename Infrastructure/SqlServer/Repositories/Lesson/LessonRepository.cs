using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Lesson
{
    public partial class LessonRepository : EntityRepository<Domain.Lesson>
    {
        public LessonRepository(LessonFactory factory) : base(factory)
        {
        }

        public override Domain.Lesson Create(Domain.Lesson t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };

            command.Parameters.AddWithValue("@" + ColSubject, t.Subject);

            t.IdLesson = (int) command.ExecuteScalar();


            return t;
        }
    }
}