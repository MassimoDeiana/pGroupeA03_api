using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Student
    {
        public int IdStudent { get; set; }
        
        public string Name { get; set; }
        
        public string FirstName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string Mail { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
        
        public int IdClass { get; set; }
    }
}