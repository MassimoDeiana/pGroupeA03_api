using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Student
{
    public class UseCaseCreateStudent : IWriting<OutputDtoStudent,InputDtoStudent>
    {
        private readonly IEntityRepository<Domain.Student> _studentRepository;

        public UseCaseCreateStudent(IEntityRepository<Domain.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        public OutputDtoStudent Execute(InputDtoStudent dto)
        {
            var studentFromDto = Mapper.GetInstance().Map<Domain.Student>(dto);

            var studentFromDb = _studentRepository.Create(studentFromDto);

            return Mapper.GetInstance().Map<OutputDtoStudent>(studentFromDb);
        }
    }
}