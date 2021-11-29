using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;

namespace Application.UseCases.Course
{
    public class UseCaseGenerateCourse
    {
        private readonly ICourseRepository _courseRepository;

        public UseCaseGenerateCourse(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public OutputDtoCourse Execute(InputDtoGenerateCourse dto)
        {
            var output = _courseRepository.GetById(dto.IdCourse);

            return Mapper.GetInstance().Map<OutputDtoCourse>(output);
        }
    }
}