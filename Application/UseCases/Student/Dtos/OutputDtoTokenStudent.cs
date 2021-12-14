namespace Application.UseCases.Student.Dtos
{
    public class OutputDtoTokenStudent
    {
        public int IdStudent { get; set; }

        public string Token { get; set; }
        
        public OutputDtoTokenStudent(Domain.Student student, string token)
        {
            IdStudent = student.IdStudent;
            Token = token;
        }
    }
}