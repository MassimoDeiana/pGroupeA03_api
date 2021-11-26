using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Student.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Student
{
    public class UseCaseGetStudent : IQuery<List<OutputDtoStudent>>
    {
        private readonly IEntityRepository<Domain.Student> _studentRepository;
        
        public UseCaseGetStudent(IEntityRepository<Domain.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<OutputDtoStudent> Execute()
        {
            var students = _studentRepository.GetAll();

            return students.Select(student => Mapper.GetInstance().Map<OutputDtoStudent>(student)).ToList();
        }
    }
}