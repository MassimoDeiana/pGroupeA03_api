using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Student
{
    public class UseCaseGetStudent : UseCaseGetEntity<OutputDtoStudent, Domain.Student>
    {
        public UseCaseGetStudent(IEntityRepository<Domain.Student> repository) : base(repository)
        {
        }
    }
}
