using System.Collections.Generic;
using Application.UseCases.Teacher.Dtos;
using Domain;

namespace Application.Services
{
    public interface ITeacherService
    {
        OutputDtoTokenTeacher Authenticate(InputDtoGenerateTokenTeacher model);
       // IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
    }
}