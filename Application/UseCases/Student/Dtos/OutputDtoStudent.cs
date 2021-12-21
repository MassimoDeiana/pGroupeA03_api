using System;

namespace Application.UseCases.Student.Dtos
{
    public class OutputDtoStudent
    {
        public int IdStudent { get; set; }
        public string Name { get; set; } 
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mail { get; set; }
        public int IdClass { get; set; }
    }
}