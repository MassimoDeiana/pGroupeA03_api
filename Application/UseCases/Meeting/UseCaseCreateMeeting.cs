using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Meeting
{
    public class UseCaseCreateMeeting : UseCaseCreateEntity<OutputDtoMeeting, InputDtoMeeting, Domain.Meeting>
    {
        public UseCaseCreateMeeting(IEntityRepository<Domain.Meeting> repository) : base(repository)
        {
        }
    }
}