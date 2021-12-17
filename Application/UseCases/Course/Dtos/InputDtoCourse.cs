using System;
using System.ComponentModel.DataAnnotations;
using Application.Helpers;

namespace Application.UseCases.Course.Dtos
{
    public class InputDtoCourse
    {
        [Required]
        public int IdLesson { get; set; }

        [Required]
        [Date]
        public DateTime StartTime { get; set; }
        
        [Required]
        [Date]
        public DateTime EndTime { get; set; }

        [Required]
        public int IdTeacher { get; set; }
        
        [Required]
        public int IdClass { get; set; }
    }
}