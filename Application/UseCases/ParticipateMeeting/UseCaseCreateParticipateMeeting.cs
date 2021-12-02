using Application.UseCases.ParticipateMeeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.ParticipateMeeting
{
    public class UseCaseCreateParticipateMeeting : UseCaseCreateEntity<OutputDtoParticipateMeeting, InputDtoParticipateMeeting, Domain.ParticipateMeeting>
    {
        public UseCaseCreateParticipateMeeting(IEntityRepository<Domain.ParticipateMeeting> repository) : base(repository)
        {
        }
    }
}