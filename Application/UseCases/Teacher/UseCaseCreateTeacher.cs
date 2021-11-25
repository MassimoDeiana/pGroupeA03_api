using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Teacher;

namespace Application.UseCases.Teacher
{
    public class UseCaseCreateTeacher : IWriting<OutputDtoTeacher,InputDtoTeacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UseCaseCreateTeacher(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        public OutputDtoTeacher Execute(InputDtoTeacher dto)
        {
            var teacherFromDto = Mapper.GetInstance().Map<Domain.Teacher>(dto);

            var teacherFromDb = _teacherRepository.Create(teacherFromDto);

            return Mapper.GetInstance().Map<OutputDtoTeacher>(teacherFromDb);
        }
    }
}