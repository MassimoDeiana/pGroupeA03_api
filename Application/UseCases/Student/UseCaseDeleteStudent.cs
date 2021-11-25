using System.Runtime.Serialization;
using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Student;

namespace Application.UseCases.Student
{
    public class UseCaseDeleteStudent : IDeleting<InputDtoGenerateStudent>
    {
        private readonly IStudentRepository _studentRepository;

        public UseCaseDeleteStudent(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool Execute(string request, InputDtoGenerateStudent dto, string col)
        {
            return _studentRepository.Delete(dto.IdStudent);
        }
    }
}