using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Teacher
{
    public partial class TeacherRepository : ITeacherRepository
    {
        
        private readonly IDomainFactory<Domain.Teacher> _teacherFactory = new TeacherFactory();

        public List<Domain.Teacher> GetAll()
        {
            var teachers = new List<Domain.Teacher>();

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
                teachers.Add(_teacherFactory.CreateFromSqlReader(reader));
            }

            return teachers;
        }

        public Domain.Teacher GetById(int id)
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
            
            return reader.Read() ? _teacherFactory.CreateFromSqlReader(reader) : null;
        }
        
        public Domain.Teacher Create(Domain.Teacher teacher)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            
            command.Parameters.AddWithValue("@" + ColName, teacher.Name);
            command.Parameters.AddWithValue("@" + ColFirstName, teacher.FirstName);
            command.Parameters.AddWithValue("@" + ColBirthDate, teacher.BirthDate);
            command.Parameters.AddWithValue("@" + ColMail, teacher.Mail);
            command.Parameters.AddWithValue("@" + ColPassword, teacher.Password);

            teacher.IdTeacher = (int) command.ExecuteScalar();

            return teacher;
        }
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