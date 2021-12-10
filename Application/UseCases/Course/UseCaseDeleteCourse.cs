using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Course
{
    public class UseCaseDeleteCourse : IDeleting<InputDtoGenerateCourse>
    {
        private readonly IEntityRepository<Domain.Course> _courseRepository;

        public UseCaseDeleteCourse(IEntityRepository<Domain.Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool Execute(InputDtoGenerateCourse dto)
        {
            return _courseRepository.Delete(dto.IdCourse);
        }
    }
}