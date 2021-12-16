using Application.UseCases.Lesson.Dtos;
using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Lesson
{
    public class UseCaseGenerateLesson : IQueryFiltering<OutputDtoLesson,InputDtoGenerateLesson>
    {
        private readonly IEntityRepository<Domain.Lesson> _lessonRepository;

        public UseCaseGenerateLesson(IEntityRepository<Domain.Lesson> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public OutputDtoLesson Execute(InputDtoGenerateLesson dto)
        {
            var output = _lessonRepository.GetById(dto.IdLesson);

            return Mapper.GetInstance().Map<OutputDtoLesson>(output);
        }
    }
}