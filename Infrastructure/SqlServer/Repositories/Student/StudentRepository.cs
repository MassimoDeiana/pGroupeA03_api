using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public partial class StudentRepository : EntityRepository<Domain.Student>, IStudentRepository
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
            command.Parameters.AddWithValue("@" + ColPassword, t.Password);
            command.Parameters.AddWithValue("@" + ColIdClass, t.IdClass);

            t.IdStudent = (int) command.ExecuteScalar();
            
            return t;
        }

        public bool Update(int id, int idClass)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqUpdateClass
            };
            
            command.Parameters.AddWithValue("@" + StudentRepository.ColId, id);
            command.Parameters.AddWithValue("@" + StudentRepository.ColIdClass, idClass);

            return command.ExecuteNonQuery() > 0;
        }
    }
}