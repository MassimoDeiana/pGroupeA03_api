using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Meeting
{
    public class UseCaseGenerateMeeting : IQueryFiltering<OutputDtoMeeting, InputDtoGenerateMeeting>
    {
        private readonly IEntityRepository<Domain.Meeting>  _meetingRepository;

        public UseCaseGenerateMeeting(IEntityRepository<Domain.Meeting> meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }


        public OutputDtoMeeting Execute(InputDtoGenerateMeeting dto)
        {
            var output = _meetingRepository.GetById(dto.IdMeeting);

            return Mapper.GetInstance().Map<OutputDtoMeeting>(output);
        }
    }
}