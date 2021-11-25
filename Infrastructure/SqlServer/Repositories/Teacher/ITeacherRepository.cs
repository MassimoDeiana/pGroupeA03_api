using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Teacher
{
    public interface ITeacherRepository
    { 
        List<Domain.Teacher> GetAll();

        Domain.Teacher GetById(int id);
        Domain.Teacher Create(Domain.Teacher teacher);

//        bool Update(int id, Domain.Teacher teacher);

        bool Delete(int id);
    }
}