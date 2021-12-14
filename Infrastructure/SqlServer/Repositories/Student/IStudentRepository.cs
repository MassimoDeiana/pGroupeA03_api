using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Student
{
    public interface IStudentRepository
    {
        bool Update(int id, int idClass);
        List<Domain.Student> GetByClass(int idClass);
    }
}