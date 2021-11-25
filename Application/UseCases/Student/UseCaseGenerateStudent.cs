using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Student;

namespace Application.UseCases.Student
{
    public class UseCaseGenerateStudent : IQueryFiltering<OutputDtoStudent,InputDtoGenerateStudent>
    {
        private readonly IStudentRepository _studentRepository;

        public UseCaseGenerateStudent(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public OutputDtoStudent Execute(string request, InputDtoGenerateStudent dto, string col)
        {
            var output = _studentRepository.GetById(dto.IdStudent);

            return Mapper.GetInstance().Map<OutputDtoStudent>(output);
        }
    }
}