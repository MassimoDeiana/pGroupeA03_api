using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Meeting
{
    public class UseCaseGetMeeting : UseCaseGetEntity<OutputDtoMeeting, Domain.Meeting>
    {
        public UseCaseGetMeeting(IEntityRepository<Domain.Meeting> repository) : base(repository)
        {
        }
    }
}