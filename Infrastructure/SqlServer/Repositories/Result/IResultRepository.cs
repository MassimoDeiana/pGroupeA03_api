using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Result
{
    public interface IResultRepository
    {
        List<Domain.ResultReport> GetById(int id);
    }
}