using Application.UseCases.Lesson.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Lesson
{
    public class UseCaseGetLesson : UseCaseGetEntity<OutputDtoLesson,Domain.Lesson>
    {
        public UseCaseGetLesson(IEntityRepository<Domain.Lesson> repository) : base(repository)
        {
        }
    }
}