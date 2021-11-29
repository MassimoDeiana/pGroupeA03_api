using System.Collections.Generic;
using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseGetSchoolClass : UseCaseGetEntity<OutputDtoSchoolClass, Domain.SchoolClass>
    {
        public UseCaseGetSchoolClass(IEntityRepository<Domain.SchoolClass> repository) : base(repository)
        {
        }
    }
}
