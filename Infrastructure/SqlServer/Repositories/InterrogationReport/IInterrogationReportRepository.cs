using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.InterrogationReport
{
    public interface IInterrogationReportRepository
    {
        List<Domain.InterrogationReport> GetById(int id);

        
    }
}