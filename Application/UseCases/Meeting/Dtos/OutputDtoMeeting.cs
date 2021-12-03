using System;

namespace Application.UseCases.Meeting.Dtos
{
    public class OutputDtoMeeting
    {
        public int IdMeeting { get; set; }
        public string Subject { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}