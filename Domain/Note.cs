using System;

namespace Domain
{
    public class Note
    {
        public int IdNote { get; set; }
        
        public int IdTeacher { get; set; }
        
        public int IdStudent { get; set; }

        public int IdInterro { get; set; }

        public DateTime DateNote { get; set; }
        
        public double Result { get; set; }
        
        public string Message { get; set; }
    }
}