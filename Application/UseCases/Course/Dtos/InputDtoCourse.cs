using System;

namespace Application.UseCases.Course.Dtos
{
    public class InputDtoCourse
    {
        public DateTime Day { get; set; }
        
        public TimeSpan Hour { get; set; }
        
        public int Duration { get; set; }
        
        public string Subject { get; set; }
    }
}