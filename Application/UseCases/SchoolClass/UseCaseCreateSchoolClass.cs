using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseCreateSchoolClass : UseCaseCreateEntity<OutputDtoSchoolClass, InputDtoSchoolClass, Domain.SchoolClass>
    {
        public UseCaseCreateSchoolClass(IEntityRepository<Domain.SchoolClass> repository) : base(repository)
        {
        }
    }
}