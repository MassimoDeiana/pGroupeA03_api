namespace Application.UseCases.Teacher.Dtos
{
    public class OutputDtoTokenTeacher
    {
        public int IdTeacher { get; set; }

        public string Token { get; set; }
        
        public OutputDtoTokenTeacher(Domain.Teacher teacher, string token)
        {
            IdTeacher = teacher.IdTeacher;
            Token = token;
        }
    }
}