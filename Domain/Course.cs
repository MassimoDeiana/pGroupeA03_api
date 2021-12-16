using System;

namespace Domain
{
    public class Course
    {
        public int IdCourse { get; set; }
        
        public int IdLesson { get; set; }

        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
        
        public int IdTeacher { get; set; }
        
        public int IdClass { get; set; }
    }
}