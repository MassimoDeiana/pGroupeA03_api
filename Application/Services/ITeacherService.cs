using Application.UseCases.Teacher.Dtos;
using Domain;

namespace Application.Services
{
    public interface ITeacherService
    {
        OutputDtoTokenTeacher Authenticate(InputDtoGenerateTokenTeacher model);
        Teacher GetById(int id);
    }
}