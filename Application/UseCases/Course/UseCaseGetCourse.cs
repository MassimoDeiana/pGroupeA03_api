using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Course
{
    public class UseCaseGetCourse : UseCaseGetEntity<OutputDtoCourse,Domain.Course>
    {
        public UseCaseGetCourse(IEntityRepository<Domain.Course> repository) : base(repository)
        {
        }
    }
}