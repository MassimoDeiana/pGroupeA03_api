using System.Collections.Generic;

namespace Infrastructure.SqlServer.Utils
{
    public interface IEntityRepository<T>
    {
        public List<T> GetAll();

        T GetById(int id);

        T Create(T t);
        
        bool Delete(int id);
    }
}