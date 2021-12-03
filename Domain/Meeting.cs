using System;

namespace Domain
{
    public class Meeting
    {
        public int IdMeeting { get; set; }
        
        public string Subject { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
    }
}