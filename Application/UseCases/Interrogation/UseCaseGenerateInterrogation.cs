using Application.UseCases.Interrogation.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Interrogation
{
    public class UseCaseGenerateInterrogation : IQueryFiltering<OutputDtoInterrogation,InputDtoGenerateInterrogation>
    {
        private readonly IEntityRepository<Domain.Interrogation> _interrogationRepository;

        public UseCaseGenerateInterrogation(IEntityRepository<Domain.Interrogation> interrogationRepository)
        {
            _interrogationRepository = interrogationRepository;
        }
        
        public OutputDtoInterrogation Execute(InputDtoGenerateInterrogation dto)
        {
            var output = _interrogationRepository.GetById(dto.IdInterro);

            return Mapper.GetInstance().Map<OutputDtoInterrogation>(output);
        }
    }
}