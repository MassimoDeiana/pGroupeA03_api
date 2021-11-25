using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting
{
    public class UseCaseCreateMeeting
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseCreateMeeting(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }


        public OutputDtoMeeting Execute(InputDtoMeeting dto)
        {
            var meetingFromDto = Mapper.GetInstance().Map<Domain.Meeting>(dto);

            var meetingFromDb = _meetingRepository.Create(meetingFromDto);

            return Mapper.GetInstance().Map<OutputDtoMeeting>(meetingFromDb);
        }
    }
}