using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Course
{
    public partial class CourseRepository : EntityRepository<Domain.Course>
    {
        public CourseRepository(CourseFactory factory) : base(factory)
        {
        }

        public override Domain.Course Create(Domain.Course t)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };

            command.Parameters.AddWithValue("@" + ColIdLesson, t.IdLesson);
            command.Parameters.AddWithValue("@" + ColStart, t.StartTime);
            command.Parameters.AddWithValue("@" + ColEnd, t.EndTime);
            command.Parameters.AddWithValue("@" + ColIdTeacher, t.IdTeacher);
            command.Parameters.AddWithValue("@" + ColIdClass, t.IdClass);

            t.IdCourse = (int) command.ExecuteScalar();

            return t;        }
    }
}