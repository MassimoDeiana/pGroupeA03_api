using Application.UseCases.Note.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Note
{
    public class UseCaseDeleteNote : IDeleting<InputDtoGenerateNote>
    {
        private readonly IEntityRepository<Domain.Note> _noteRepository;

        public UseCaseDeleteNote(IEntityRepository<Domain.Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public bool Execute(InputDtoGenerateNote dto)
        {
            return _noteRepository.Delete(dto.IdNote);
        }
    }
}