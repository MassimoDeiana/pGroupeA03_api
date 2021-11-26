using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Meeting
{
    public class UseCaseDeleteMeeting : IDeleting<InputDtoGenerateMeeting>
    {
        private readonly IEntityRepository<Domain.Meeting>  _meetingRepository;

        public UseCaseDeleteMeeting(IEntityRepository<Domain.Meeting> meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public bool Execute(InputDtoGenerateMeeting dto)
        {
            return _meetingRepository.Delete(dto.IdMeeting);
        }
        
    }
}