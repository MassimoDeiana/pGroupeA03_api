using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Student
{
    public class UseCaseCreateStudent : UseCaseCreateEntity<OutputDtoStudent, InputDtoStudent, Domain.Student>
    {
        public UseCaseCreateStudent(IEntityRepository<Domain.Student> repository) : base(repository)
        {
        }
    }
}
