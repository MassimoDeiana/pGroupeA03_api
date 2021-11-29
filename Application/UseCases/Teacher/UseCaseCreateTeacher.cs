using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Teacher
{
    public class UseCaseCreateTeacher : UseCaseCreateEntity<OutputDtoTeacher, InputDtoTeacher, Domain.Teacher>
    {
        public UseCaseCreateTeacher(IEntityRepository<Domain.Teacher> repository) : base(repository)
        {
        }
    }
}