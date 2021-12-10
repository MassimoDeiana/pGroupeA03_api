using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Note.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Note;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Note
{
    public class UseCaseGenerateNote : IQueryFiltering<List<OutputDtoNote>, InputDtoGetNote>
    {
        private readonly INoteRepository _noteRepository;

        public UseCaseGenerateNote(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }


        public List<OutputDtoNote> Execute(InputDtoGetNote dto)
        {
            var output = _noteRepository.GetById(dto.IdStudent);

            return output.Select(t => Mapper.GetInstance().Map<OutputDtoNote>(t)).ToList();
        }
    }
}