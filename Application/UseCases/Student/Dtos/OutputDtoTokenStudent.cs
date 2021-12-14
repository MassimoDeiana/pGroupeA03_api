namespace Application.UseCases.Student.Dtos
{
    public class OutputDtoTokenStudent
    {
        public int IdStudent { get; set; }

        public string Token { get; set; }
        
        public OutputDtoTokenStudent(Domain.Student teacher, string token)
        {
            IdStudent = teacher.IdStudent;
            Token = token;
        }
    }
}