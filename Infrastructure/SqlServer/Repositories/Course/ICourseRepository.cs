using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Course
{
    public interface ICourseRepository
    {
        List<Domain.Course> GetByTeacher(int id);

    }
}