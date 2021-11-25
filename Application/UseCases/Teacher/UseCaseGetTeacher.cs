using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Teacher;

namespace Application.UseCases.Teacher
{
    public class UseCaseGetTeacher : IQuery<List<OutputDtoTeacher>>
    {
        private readonly ITeacherRepository _teacherRepository;
        
        public UseCaseGetTeacher(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public List<OutputDtoTeacher> Execute()
        {
            var teachers = _teacherRepository.GetAll();

            return teachers.Select(t => Mapper.GetInstance().Map<OutputDtoTeacher>(t)).ToList();
        }
    }
}