using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Note
{
    public class NoteFactory : IDomainFactory<Domain.Note>
    {
        /**
         * <summary>Méthode qui lit le résultat d'une requête et transforme les informations en un objet
         * <returns>Note</returns></summary>
         */
        public Domain.Note CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Note
            {
                IdNote = reader.GetInt32(reader.GetOrdinal(NoteRepository.ColId)),
                IdTeacher = reader.GetInt32(reader.GetOrdinal(NoteRepository.ColIdTeacher)),
                IdStudent = reader.GetInt32(reader.GetOrdinal(NoteRepository.ColIdStudent)),
                IdInterro = reader.GetInt32(reader.GetOrdinal(NoteRepository.ColIdInterro)),
                DateNote = reader.GetDateTime(reader.GetOrdinal(NoteRepository.ColDateNote)),
                Result = reader.GetDouble(reader.GetOrdinal(NoteRepository.ColResult)),
                Message = reader.GetString(reader.GetOrdinal(NoteRepository.ColMessage))
            };
        }
    }
}