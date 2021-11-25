using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Meeting
{
    public interface IMeetingRepository
    {
        List<Domain.Meeting> GetAll();
        Domain.Meeting GetById(int id);
        Domain.Meeting Create(Domain.Meeting meeting);
        bool Delete(int id);
    }
}