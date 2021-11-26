using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Teacher
{
    public partial class TeacherRepository : EntityRepository<Domain.Teacher>
    {
/*
        public bool Update(int id, Domain.Teacher teacher)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqUpdate
            };
            command.Parameters.AddWithValue("@" + ColId, teacher.IdTeacher);
            command.Parameters.AddWithValue("@" + ColName, teacher.Name);
            command.Parameters.AddWithValue("@" + ColFirstName, teacher.FirstName);
            command.Parameters.AddWithValue("@" + ColBirthDate, teacher.BirthDate);
            command.Parameters.AddWithValue("@" + ColMail, teacher.Mail);

            return command.ExecuteNonQuery() > 0;
        }
*/
        public TeacherRepository(TeacherFactory factory) : base(factory)
        {
        }

        public override Domain.Teacher Create(Domain.Teacher t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            
            command.Parameters.AddWithValue("@" + ColName, t.Name);
            command.Parameters.AddWithValue("@" + ColFirstName, t.FirstName);
            command.Parameters.AddWithValue("@" + ColBirthDate, t.BirthDate);
            command.Parameters.AddWithValue("@" + ColMail, t.Mail);
            command.Parameters.AddWithValue("@" + ColPassword, t.Password);

            t.IdTeacher = (int) command.ExecuteScalar();

            return t;
        }

        public override bool Update(int id, Domain.Teacher t)
        {
            throw new NotImplementedException();
        }
    }
}