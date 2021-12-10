using Application.UseCases.Interrogation.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Interrogation
{
    public class UseCaseGetInterrogation : UseCaseGetEntity<OutputDtoInterrogation, Domain.Interrogation>
    {
        public UseCaseGetInterrogation(IEntityRepository<Domain.Interrogation> repository) : base(repository)
        {
        }
    }
}