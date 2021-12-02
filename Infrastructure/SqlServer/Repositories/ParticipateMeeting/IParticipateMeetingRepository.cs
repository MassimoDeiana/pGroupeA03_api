using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.ParticipateMeeting
{
    public interface IParticipateMeetingRepository
    {
        List<Domain.ParticipateMeeting> GetById(int id);
    }
}