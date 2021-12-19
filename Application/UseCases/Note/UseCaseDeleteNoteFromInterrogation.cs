using Application.UseCases.Note.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Note;

namespace Application.UseCases.Note
{
    public class UseCaseDeleteNoteFromInterrogation : IDeleting<InputDtoDeleteNoteFromInterrogation>
    {
        private readonly INoteRepository _noteRepository;

        public UseCaseDeleteNoteFromInterrogation(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public bool Execute(InputDtoDeleteNoteFromInterrogation dto)
        {
            return _noteRepository.Delete(dto.IdInterro, dto.IdStudent);
        }
    }
}