using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Interrogation
{
    public interface IInterrogationRepository
    {
        List<Domain.Interrogation> GetByTeacher(int id);
    }
}