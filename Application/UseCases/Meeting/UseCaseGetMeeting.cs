using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Meeting
{
    public class UseCaseGetMeeting : IQuery<List<OutputDtoMeeting>>
    {
        private readonly IEntityRepository<Domain.Meeting>  _meetingRepository;
        
        public UseCaseGetMeeting(IEntityRepository<Domain.Meeting> meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public List<OutputDtoMeeting> Execute()
        {
            var meetings = _meetingRepository.GetAll();

            return meetings.Select(t => Mapper.GetInstance().Map<OutputDtoMeeting>(t)).ToList();
        }
    }
}