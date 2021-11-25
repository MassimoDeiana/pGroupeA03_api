namespace Application.UseCases.Teacher.Dtos
{
    public class OutputDtoTokenTeacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }
        
        public OutputDtoTokenTeacher(Domain.Teacher teacher, string token)
        {
            FirstName = teacher.FirstName;
            LastName = teacher.Name;
            Mail = teacher.Mail;
            Token = token;
        }
    }
}