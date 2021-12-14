using Application.UseCases.Student.Dtos;
using Domain;

namespace Application.Services
{
    public interface IStudentService
    {
        OutputDtoTokenStudent Authenticate(InputDtoGenerateTokenStudent model);
        Student GetById(int id);
    }
}