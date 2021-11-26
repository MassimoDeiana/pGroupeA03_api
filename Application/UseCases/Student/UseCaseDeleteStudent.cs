using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Student
{
    public class UseCaseDeleteStudent : IDeleting<InputDtoGenerateStudent>
    {
        private readonly IEntityRepository<Domain.Student> _studentRepository;

        public UseCaseDeleteStudent(IEntityRepository<Domain.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool Execute(InputDtoGenerateStudent dto)
        {
            return _studentRepository.Delete(dto.IdStudent);
        }
    }
}