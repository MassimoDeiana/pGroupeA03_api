using System;

namespace Application.UseCases.Meeting.Dtos
{
    public class InputDtoMeeting
    {
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}