using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Course
{
    public class CourseFactory : IDomainFactory<Domain.Course>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>Course</returns></summary>
         */
        public Domain.Course CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Course
            {
                IdCourse = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColId)),
                IdLesson = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColIdLesson)),
                StartTime = reader.GetDateTime(reader.GetOrdinal(CourseRepository.ColStart)),
                EndTime= reader.GetDateTime(reader.GetOrdinal(CourseRepository.ColEnd)),
                IdTeacher = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColIdTeacher)),
                IdClass = reader.GetInt32(reader.GetOrdinal(CourseRepository.ColIdClass))
            };    
        }
    }
}