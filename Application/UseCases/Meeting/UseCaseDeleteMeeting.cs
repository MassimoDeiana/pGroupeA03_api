using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting
{
    public class UseCaseDeleteMeeting : IDeleting<InputDtoGenerateMeeting>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseDeleteMeeting(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public bool Execute(string request, InputDtoGenerateMeeting dto, string col)
        {
            return _meetingRepository.Delete(dto.IdMeeting);
        }
        
    }
}