using Application.UseCases.ParticipateMeeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.ParticipateMeeting
{
    public class UseCaseDeleteParticipateMeeting : IDeleting<InputDtoGenerateParticipateMeeting>
    {
        private readonly IEntityRepository<Domain.ParticipateMeeting> _participateMeetingRepository;

        public UseCaseDeleteParticipateMeeting(IEntityRepository<Domain.ParticipateMeeting> participateMeetingRepository)
        {
            _participateMeetingRepository = participateMeetingRepository;
        }

        public bool Execute(InputDtoGenerateParticipateMeeting dto)
        {
            return _participateMeetingRepository.Delete(dto.IdMeeting);
        }
    }
}