using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Course
{
    public class UseCaseGenerateCourse
    {
        private readonly IEntityRepository<Domain.Course> _courseRepository;

        public UseCaseGenerateCourse(IEntityRepository<Domain.Course> courseRepository)
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