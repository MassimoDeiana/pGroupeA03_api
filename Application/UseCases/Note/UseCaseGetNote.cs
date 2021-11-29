using Application.UseCases.Note.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Note
{
    public class UseCaseGetNote : UseCaseGetEntity<OutputDtoNote, Domain.Note>
    {
        public UseCaseGetNote(IEntityRepository<Domain.Note> repository) : base(repository)
        {
        }
    }
}