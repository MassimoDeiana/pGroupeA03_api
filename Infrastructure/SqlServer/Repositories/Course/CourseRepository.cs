using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Course
{
    public partial class CourseRepository : ICourseRepository
    {
        private readonly IDomainFactory<Domain.Course> _courseFactory = new CourseFactory();

        public List<Domain.Course> GetAll()
        {
            var courses = new List<Domain.Course>();

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
                courses.Add(_courseFactory.CreateFromSqlReader(reader));
            }

            return courses;
        }

        public Domain.Course GetById(int id)
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
            
            return reader.Read() ? _courseFactory.CreateFromSqlReader(reader) : null;
        }
        
        public Domain.Course Create(Domain.Course course)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            
            command.Parameters.AddWithValue("@" + ColDay, course.Day.Date);
            command.Parameters.AddWithValue("@" + ColHour, course.Hour);
            command.Parameters.AddWithValue("@" + ColDuration, course.Duration);
            command.Parameters.AddWithValue("@" + ColSubject, course.Subject);
            

            course.IdCourse = (int) command.ExecuteScalar();

            return course;
        }

        
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