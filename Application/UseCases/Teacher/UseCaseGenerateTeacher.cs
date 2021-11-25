using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Teacher;

namespace Application.UseCases.Teacher
{
    public class UseCaseGenerateTeacher : IQueryFiltering<OutputDtoTeacher,InputDtoGenerateTeacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UseCaseGenerateTeacher(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        
        public OutputDtoTeacher Execute(string request, InputDtoGenerateTeacher dto, string col)
        {
            var output = _teacherRepository.GetById(dto.IdTeacher);

            return Mapper.GetInstance().Map<OutputDtoTeacher>(output);
        }
        
    }
}