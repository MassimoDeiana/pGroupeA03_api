using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Meeting
{
    public class UseCaseCreateMeeting : IWriting<OutputDtoMeeting, InputDtoMeeting>
    {
        private readonly IEntityRepository<Domain.Meeting>  _meetingRepository;

        public UseCaseCreateMeeting(IEntityRepository<Domain.Meeting> meetingRepository)
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