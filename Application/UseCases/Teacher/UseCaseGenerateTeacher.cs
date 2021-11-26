using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Teacher;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Teacher
{
    public class UseCaseGenerateTeacher : IQueryFiltering<OutputDtoTeacher,InputDtoGenerateTeacher>
    {
        private readonly IEntityRepository<Domain.Teacher> _teacherRepository;

        public UseCaseGenerateTeacher(IEntityRepository<Domain.Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        
        public OutputDtoTeacher Execute(InputDtoGenerateTeacher dto)
        {
            var output = _teacherRepository.GetById(dto.IdTeacher);

            return Mapper.GetInstance().Map<OutputDtoTeacher>(output);
        }
        
    }
}