using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public partial class StudentRepository : EntityRepository<Domain.Student>
    {

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
    }
}