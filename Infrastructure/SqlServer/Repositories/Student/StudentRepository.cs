using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public partial class StudentRepository : IStudentRepository
    {
       

        private readonly IDomainFactory<Domain.Student> _studentFactory = new StudentFactory();

        public List<Domain.Student> GetAll()
        {
            var eleves = new List<Domain.Student>();

            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = StudentRepository.ReqGetAll
            };

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                eleves.Add(_studentFactory.CreateFromSqlReader(reader));
            }

            return eleves;
        }

        public Domain.Student GetById(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = StudentRepository.ReqGetById
            };
            command.Parameters.AddWithValue("@" + StudentRepository.ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            
            return reader.Read() ? _studentFactory.CreateFromSqlReader(reader) : null;
        }

        
        public Domain.Student Create(Domain.Student student)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = StudentRepository.ReqCreate
            };
            command.Parameters.AddWithValue("@" + StudentRepository.ColName, student.Name);
            command.Parameters.AddWithValue("@" + StudentRepository.ColFirstname, student.FirstName);
            command.Parameters.AddWithValue("@" + StudentRepository.ColBirthdate, student.BirthDate);
            command.Parameters.AddWithValue("@" + StudentRepository.ColMail, student.Mail);
            command.Parameters.AddWithValue("@" + StudentRepository.ColIdClass, student.IdClass);

            student.IdStudent = (int) command.ExecuteScalar();
            
            return student;
        }



        /*
        public bool Update(int id, Domain.Student student)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = StudentRepository.ReqUpdate
            };
            command.Parameters.AddWithValue("@" + StudentRepository.ColId, student.IdStudent);
            command.Parameters.AddWithValue("@" + StudentRepository.ColName, student.Name);
            command.Parameters.AddWithValue("@" + StudentRepository.ColFirstname, student.FirstName);
            command.Parameters.AddWithValue("@" + StudentRepository.ColBirthdate, student.BirthDate);
            command.Parameters.AddWithValue("@" + StudentRepository.ColMail, student.Mail);
            command.Parameters.AddWithValue("@" + StudentRepository.ColIdClass, student.IdClass);

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
                CommandText = StudentRepository.ReqDelete
            };

            command.Parameters.AddWithValue("@" + StudentRepository.ColId, id);
            return command.ExecuteNonQuery() > 0;
        }

    }
}