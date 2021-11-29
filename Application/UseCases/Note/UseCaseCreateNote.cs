using Application.UseCases.Note.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Note
{
    public class UseCaseCreateNote : UseCaseCreateEntity<OutputDtoNote, InputDtoNote, Domain.Note>
    {
        public UseCaseCreateNote(IEntityRepository<Domain.Note> repository) : base(repository)
        {
        }
    }
}