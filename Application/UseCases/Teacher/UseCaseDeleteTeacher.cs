using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Teacher
{
    public class UseCaseDeleteTeacher : IDeleting<InputDtoGenerateTeacher>
    {
        private readonly IEntityRepository<Domain.Teacher> _teacherRepository;

        public UseCaseDeleteTeacher(IEntityRepository<Domain.Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public bool Execute(InputDtoGenerateTeacher dto)
        {
            return _teacherRepository.Delete(dto.IdTeacher);
        }
    }
}