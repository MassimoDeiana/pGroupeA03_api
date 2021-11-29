using System;

namespace Domain
{
    public class Course
    {
        public int IdCourse { get; set; }
        public DateTime Day { get; set; }
        
        public TimeSpan Hour { get; set; }
        
        public int Duration { get; set; }
        
        public string Subject { get; set; }
        
        public int IdTeacher { get; set; }
        
        public int IdClass { get; set; }
    }
}