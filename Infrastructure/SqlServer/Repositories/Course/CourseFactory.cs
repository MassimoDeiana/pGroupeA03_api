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
                Day = reader.GetDateTime(reader.GetOrdinal(CourseRepository.ColDay)),
                Hour= reader.GetTimeSpan(reader.GetOrdinal(CourseRepository.ColHour)),
                Duration = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColDuration)),
                Subject = reader.GetString(reader.GetOrdinal(CourseRepository.ColSubject))

            };    
        }
    }
}