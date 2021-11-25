using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Student.Dtos;
using Application.UseCases.Teacher.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Student;

namespace Application.UseCases.Student
{
    public class UseCaseGetStudent : IQuery<List<OutputDtoStudent>>
    {
        private readonly IStudentRepository _studentRepository;


        public UseCaseGetStudent(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<OutputDtoStudent> Execute()
        {
            var students = _studentRepository.GetAll();

            /* EQUIVALENT A LA LIGNE EN DESSOUS
             var output = new List<OutputDtoStudent>();
             
                foreach (Domain.Student student in students)
                {
                    output.Add(Mapper.GetInstance().Map<OutputDtoStudent>(student));
                }
            
            return output;
            */

            return students.Select(student => Mapper.GetInstance().Map<OutputDtoStudent>(student)).ToList();
        }
    }
}