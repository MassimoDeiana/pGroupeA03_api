using Application.UseCases.Interrogation.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Interrogation
{
    public class UseCaseDeleteInterrogation : IDeleting<InputDtoGenerateInterrogation>
    {
        private readonly IEntityRepository<Domain.Interrogation> _interrogationRepository;

        public UseCaseDeleteInterrogation(IEntityRepository<Domain.Interrogation> interrogationRepository)
        {
            _interrogationRepository = interrogationRepository;
        }


        public bool Execute(InputDtoGenerateInterrogation dto)
        {
            return _interrogationRepository.Delete(dto.IdInterro);
        }
    }
}