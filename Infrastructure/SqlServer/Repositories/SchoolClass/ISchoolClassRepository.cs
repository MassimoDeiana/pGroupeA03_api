using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.SchoolClass
{
    public interface ISchoolClassRepository
    {
        public List<Domain.SchoolClass> GetAll();

        Domain.SchoolClass GetById(int id);

        Domain.SchoolClass Create(Domain.SchoolClass schoolClass);
        
        bool Delete(int id);
    }
}