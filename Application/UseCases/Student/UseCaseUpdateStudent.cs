using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Student
{
    public class UseCaseUpdateStudent : IUpdating<InputDtoStudent>
    {
        private readonly IEntityRepository<Domain.Student> _studentRepository;

        public UseCaseUpdateStudent(IEntityRepository<Domain.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool Execute(int id, InputDtoStudent dto)
        {
            var studentFromDto = Mapper.GetInstance().Map<Domain.Student>(dto);
            
            return _studentRepository.Update(id, studentFromDto);
        }
    }
}