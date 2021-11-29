using Application.UseCases.Note.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Note
{
    public class UseCaseGenerateNote : IQueryFiltering<OutputDtoNote, InputDtoGenerateNote>
    {
        private readonly IEntityRepository<Domain.Note> _noteRepository;

        public UseCaseGenerateNote(IEntityRepository<Domain.Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }


        public OutputDtoNote Execute(InputDtoGenerateNote dto)
        {
            var output = _noteRepository.GetById(dto.IdNote);

            return Mapper.GetInstance().Map<OutputDtoNote>(output);
        }
    }
}