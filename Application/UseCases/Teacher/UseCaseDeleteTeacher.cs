using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Teacher;

namespace Application.UseCases.Teacher
{
    public class UseCaseDeleteTeacher : IDeleting<InputDtoGenerateTeacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UseCaseDeleteTeacher(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public bool Execute(string request, InputDtoGenerateTeacher dto, string col)
        {
            return _teacherRepository.Delete(dto.IdTeacher);
        }
    }
}