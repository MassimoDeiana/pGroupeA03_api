using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;

namespace Application.UseCases.Course
{
    public class UseCaseCreateCourse
    {
        private readonly ICourseRepository _courseRepository;

        public UseCaseCreateCourse(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public OutputDtoCourse Execute(InputDtoCourse dto)
        {
            var courseFromDto = Mapper.GetInstance().Map<Domain.Course>(dto);

            var courseFromDb = _courseRepository.Create(courseFromDto);

            return Mapper.GetInstance().Map<OutputDtoCourse>(courseFromDb);
        }
    }
}