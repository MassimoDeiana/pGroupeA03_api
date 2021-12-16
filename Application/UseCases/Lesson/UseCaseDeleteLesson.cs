using Application.UseCases.Lesson.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Lesson
{
    public class UseCaseDeleteLesson : IDeleting<InputDtoGenerateLesson>
    {
        private readonly IEntityRepository<Domain.Lesson> _lessonRepository;

        public UseCaseDeleteLesson(IEntityRepository<Domain.Lesson> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public bool Execute(InputDtoGenerateLesson dto)
        {
            return _lessonRepository.Delete(dto.IdLesson);
        }
    }
}