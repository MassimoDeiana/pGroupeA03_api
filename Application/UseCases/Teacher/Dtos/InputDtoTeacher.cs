using System;

namespace Application.UseCases.Teacher.Dtos
{
    public class InputDtoTeacher
    {
        public string Name { get; set; }
        
        public string Firstname { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string Mail { get; set; }
        
        public string Password { get; set; }
    }
}