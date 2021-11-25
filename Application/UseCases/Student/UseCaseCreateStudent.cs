using Application.UseCases.Student.Dtos;
using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Student;

namespace Application.UseCases.Student
{
    public class UseCaseCreateStudent : IWriting<OutputDtoStudent,InputDtoStudent>
    {
        private readonly IStudentRepository _studentRepository;

        public UseCaseCreateStudent(IStudentRepository studentRepository)
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