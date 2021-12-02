using System;

namespace Application.UseCases.Teacher.Dtos
{
    public class OutputDtoTeacher
    { 
        public int IdTeacher { get; set; }
        
        public string Name { get; set; } 
        
        public string Firstname { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string Mail { get; set; }
    }
}