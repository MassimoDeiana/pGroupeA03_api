using Application.UseCases.Interrogation.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Interrogation
{
    public class UseCaseCreateInterrogation : UseCaseCreateEntity<OutputDtoInterrogation,InputDtoInterrogation,Domain.Interrogation>
    {
        public UseCaseCreateInterrogation(IEntityRepository<Domain.Interrogation> repository) : base(repository)
        {
        }
    }
}