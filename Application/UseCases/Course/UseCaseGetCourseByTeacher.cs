using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Course.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Course;

namespace Application.UseCases.Course
{
    public class UseCaseGetCourseByTeacher : IQueryFiltering<List<OutputDtoCourse>, InputDtoGenerateCourseByTeacher>
    {
        private readonly ICourseRepository _courseRepository;

        public UseCaseGetCourseByTeacher(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        
        public List<OutputDtoCourse> Execute(InputDtoGenerateCourseByTeacher dto)
        {
            var output = _courseRepository.GetByTeacher(dto.IdTeacher);
            
            return output.Select(t => Mapper.GetInstance().Map<OutputDtoCourse>(t)).ToList();
        }
    }
}