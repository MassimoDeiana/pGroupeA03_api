using System.Collections.Generic;
using System.Linq;
using Application.UseCases.ParticipateMeeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.ParticipateMeeting;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.ParticipateMeeting
{
    public class UseCaseGenerateParticipateMeeting : IQueryFiltering<List<OutputDtoParticipateMeeting>, InputDtoGenerateParticipateMeeting>
    {
        private readonly IParticipateMeetingRepository _participateMeetingRepository;

        public UseCaseGenerateParticipateMeeting(IParticipateMeetingRepository participateMeetingRepository)
        {
            _participateMeetingRepository = participateMeetingRepository;
        }
        
        public List<OutputDtoParticipateMeeting> Execute(InputDtoGenerateParticipateMeeting dto)
        {
            var output = _participateMeetingRepository.GetById(dto.IdTeacher);

            return output.Select(t => Mapper.GetInstance().Map<OutputDtoParticipateMeeting>(t)).ToList();
        }
    }
}