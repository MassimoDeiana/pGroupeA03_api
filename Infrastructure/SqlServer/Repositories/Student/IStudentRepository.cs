using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public interface IStudentRepository
    {
        List<Domain.Student> GetAll();

        Domain.Student GetById(int id);
        Domain.Student Create(Domain.Student student);

//        bool Update(int id, Domain.Student student);

        bool Delete(int id);
    }
}