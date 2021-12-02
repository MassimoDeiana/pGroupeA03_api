using Application.UseCases.ParticipateMeeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.ParticipateMeeting
{
    public class UseCaseGetParticipateMeeting : UseCaseGetEntity<OutputDtoParticipateMeeting, Domain.ParticipateMeeting>
    {
        public UseCaseGetParticipateMeeting(IEntityRepository<Domain.ParticipateMeeting> repository) : base(repository)
        {
        }
    }
}