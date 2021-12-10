using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repositories.Note
{
    public interface INoteRepository
    { 
        List<Domain.Note> GetById(int id);
    }
}