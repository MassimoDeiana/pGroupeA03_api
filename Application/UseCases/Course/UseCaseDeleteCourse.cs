using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;

namespace Application.UseCases.Course
{
    public class UseCaseDeleteCourse : IDeleting<InputDtoGenerateCourse>
    {
        private readonly ICourseRepository _courseRepository;

        public UseCaseDeleteCourse(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool Execute(InputDtoGenerateCourse dto)
        {
            return _courseRepository.Delete(dto.IdCourse);
        }
    }
}