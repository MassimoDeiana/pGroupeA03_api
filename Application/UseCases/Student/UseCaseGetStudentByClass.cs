using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Student;

namespace Application.UseCases.Student
{
    public class UseCaseGetStudentByClass
    {
        private readonly IStudentRepository _studentRepository;

        public UseCaseGetStudentByClass(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<OutputDtoStudent> Execute(InputDtoGenerateListStudent dto)
        {
            var output = _studentRepository.GetByClass(dto.IdClass);

            return output.Select(t => Mapper.GetInstance().Map<OutputDtoStudent>(t)).ToList();
        }
    }
}