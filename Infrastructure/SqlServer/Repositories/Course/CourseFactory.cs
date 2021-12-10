using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Course
{
    public class CourseFactory : IDomainFactory<Domain.Course>
    {
        public Domain.Course CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Course
            {
                IdCourse = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColId)),
                StartTime = reader.GetDateTime(reader.GetOrdinal(CourseRepository.ColStart)),
                EndTime= reader.GetDateTime(reader.GetOrdinal(CourseRepository.ColEnd)),
                Subject = reader.GetString(reader.GetOrdinal(CourseRepository.ColSubject)),
                IdTeacher = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColIdTeacher)),
                IdClass = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColIdClass))
            };    
        }
    }
}