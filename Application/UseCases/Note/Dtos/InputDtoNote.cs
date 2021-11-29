using System;

namespace Application.UseCases.Note.Dtos
{
    public class InputDtoNote
    {
        public int IdTeacher { get; set; }
        
        public int IdStudent { get; set; }
        
        public DateTime DateNote { get; set; }
        
        public string Message { get; set; }
    }
}