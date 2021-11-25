using System.Collections.Generic;

namespace Infrastructure.SqlServer.Utils
{
    public interface IEntityRepository<T>
    {
        public List<T> GetAll();

        T GetById(string request, int id, string col);

        T Create(T t);
        
        bool Delete(string request, int id, string col);
    }
}