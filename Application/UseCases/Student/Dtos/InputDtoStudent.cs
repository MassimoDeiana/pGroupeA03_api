using System;

namespace Application.UseCases.Student.Dtos
{
    public class InputDtoStudent
    {
        public string Name { get; set; }
        
        public string Firstname { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string Mail { get; set; }
        
        public string Password { get; set; }
        
        public int IdClass { get; set; }
    }
}