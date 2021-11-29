using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Course
{
    public interface ICourseRepository
    {
        
        List<Domain.Course> GetAll();
        Domain.Course GetById(int id);
        Domain.Course Create(Domain.Course course);
        bool Delete(int id);
        
    }
}