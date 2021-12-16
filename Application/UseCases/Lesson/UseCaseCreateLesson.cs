using Application.UseCases.Lesson.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Lesson
{
    public class UseCaseCreateLesson : UseCaseCreateEntity<OutputDtoLesson, InputDtoLesson,Domain.Lesson>
    {
        public UseCaseCreateLesson(IEntityRepository<Domain.Lesson> repository) : base(repository)
        {
        }
    }
}