using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting
{
    public class UseCaseGenerateMeeting : IQueryFiltering<OutputDtoMeeting, InputDtoGenerateMeeting>
    {
        private readonly IMeetingRepository _meetingRepository;

        public UseCaseGenerateMeeting(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }


        public OutputDtoMeeting Execute(string request, InputDtoGenerateMeeting dto, string col)
        {
            var output = _meetingRepository.GetById(dto.IdMeeting);

            return Mapper.GetInstance().Map<OutputDtoMeeting>(output);
        }
    }
}