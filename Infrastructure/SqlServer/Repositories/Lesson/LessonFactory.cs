using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Lesson
{
    public class LessonFactory : IDomainFactory<Domain.Lesson>
    {
        public Domain.Lesson CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Lesson
            {
                IdLesson = reader.GetInt32(reader.GetOrdinal(LessonRepository.ColId)),
                Subject = reader.GetString(reader.GetOrdinal(LessonRepository.ColSubject))
            };
        }
    }
}