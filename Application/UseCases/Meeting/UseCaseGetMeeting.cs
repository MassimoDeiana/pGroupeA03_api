using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Meeting;

namespace Application.UseCases.Meeting
{
    public class UseCaseGetMeeting : IQuery<List<OutputDtoMeeting>>
    {
        private readonly IMeetingRepository _meetingRepository;
        
        public UseCaseGetMeeting(IMeetingRepository meetingRepository)
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