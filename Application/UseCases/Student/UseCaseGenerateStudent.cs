using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Student
{
    public class UseCaseGenerateStudent : IQueryFiltering<OutputDtoStudent,InputDtoGenerateStudent>
    {
        private readonly IEntityRepository<Domain.Student> _studentRepository;

        public UseCaseGenerateStudent(IEntityRepository<Domain.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public OutputDtoStudent Execute(InputDtoGenerateStudent dto)
        {
            var output = _studentRepository.GetById(dto.IdStudent);

            return Mapper.GetInstance().Map<OutputDtoStudent>(output);
        }
    }
}