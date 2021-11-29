using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public partial class StudentRepository : EntityRepository<Domain.Student>
    {
        public StudentRepository(StudentFactory factory) : base(factory)
        {
        }

        public override Domain.Student Create(Domain.Student t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            command.Parameters.AddWithValue("@" + ColName, t.Name);
            command.Parameters.AddWithValue("@" + ColFirstname, t.FirstName);
            command.Parameters.AddWithValue("@" + ColBirthdate, t.BirthDate);
            command.Parameters.AddWithValue("@" + ColMail, t.Mail);
            command.Parameters.AddWithValue("@" + ColIdClass, t.IdClass);

            t.IdStudent = (int) command.ExecuteScalar();
            
            return t;
        }

        public override bool Update(int id, Domain.Student t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqUpdate
            };
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColName, t.Name);
            command.Parameters.AddWithValue("@" + ColFirstname, t.FirstName);
            command.Parameters.AddWithValue("@" + ColBirthdate, t.BirthDate);
            command.Parameters.AddWithValue("@" + ColMail, t.Mail);
            command.Parameters.AddWithValue("@" + ColIdClass, t.IdClass);

            return command.ExecuteNonQuery() > 0;
        }
    }
}