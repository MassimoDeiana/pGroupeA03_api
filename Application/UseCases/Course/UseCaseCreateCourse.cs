using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Course
{
    public class UseCaseCreateCourse : UseCaseCreateEntity<OutputDtoCourse,InputDtoCourse,Domain.Course>
    {
        public UseCaseCreateCourse(IEntityRepository<Domain.Course> repository) : base(repository)
        {
        }
    }
}