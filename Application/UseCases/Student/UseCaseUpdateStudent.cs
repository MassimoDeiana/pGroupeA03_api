using Infrastructure.SqlServer.Repositories.Student;

namespace Application.UseCases.Student
{
    public class UseCaseUpdateStudent
    {
        private readonly IStudentRepository _studentRepository;

        public UseCaseUpdateStudent(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool Execute(int id, int idClass)
        {
            return _studentRepository.Update(id, idClass);
        }
    }
}