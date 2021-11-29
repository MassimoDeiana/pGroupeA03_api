using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;

namespace Application.UseCases.Course
{
    public class UseCaseGetCourse
    {
        private readonly ICourseRepository _courseRepository;
        
        public UseCaseGetCourse(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<OutputDtoCourse> Execute()
        {
            var courses = _courseRepository.GetAll();

            return courses.Select(t => Mapper.GetInstance().Map<OutputDtoCourse>(t)).ToList();
        }
    }
}