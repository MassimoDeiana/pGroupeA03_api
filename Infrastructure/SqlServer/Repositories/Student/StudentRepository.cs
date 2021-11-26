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
                CommandText = StudentRepository.ReqCreate
            };
            command.Parameters.AddWithValue("@" + StudentRepository.ColName, t.Name);
            command.Parameters.AddWithValue("@" + StudentRepository.ColFirstname, t.FirstName);
            command.Parameters.AddWithValue("@" + StudentRepository.ColBirthdate, t.BirthDate);
            command.Parameters.AddWithValue("@" + StudentRepository.ColMail, t.Mail);
            command.Parameters.AddWithValue("@" + StudentRepository.ColIdClass, t.IdClass);

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
            command.Parameters.AddWithValue("@" + StudentRepository.ColId, id);
            command.Parameters.AddWithValue("@" + StudentRepository.ColName, t.Name);
            command.Parameters.AddWithValue("@" + StudentRepository.ColFirstname, t.FirstName);
            command.Parameters.AddWithValue("@" + StudentRepository.ColBirthdate, t.BirthDate);
            command.Parameters.AddWithValue("@" + StudentRepository.ColMail, t.Mail);
            command.Parameters.AddWithValue("@" + StudentRepository.ColIdClass, t.IdClass);

            return command.ExecuteNonQuery() > 0;
        }
    }
}