using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Teacher
{
    public class UseCaseCreateTeacher : IWriting<OutputDtoTeacher,InputDtoTeacher>
    {
        private readonly IEntityRepository<Domain.Teacher> _teacherRepository;

        public UseCaseCreateTeacher(IEntityRepository<Domain.Teacher> teacherRepository)
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