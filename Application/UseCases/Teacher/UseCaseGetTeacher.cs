using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Teacher
{
    public class UseCaseGetTeacher : UseCaseGetEntity<OutputDtoTeacher, Domain.Teacher>
    {
        public UseCaseGetTeacher(IEntityRepository<Domain.Teacher> repository) : base(repository)
        {
        }
    }
}