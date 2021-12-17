using System;
using System.ComponentModel.DataAnnotations;
using Application.Helpers;

namespace Application.UseCases.Note.Dtos
{
    public class InputDtoNote
    {
        [Required]
        public int IdTeacher { get; set; }
        
        [Required]
        public int IdStudent { get; set; }
        
        [Required]
        public int IdInterro { get; set; }

        [Required]
        [Date]
        public DateTime DateNote { get; set; }
        
        [Required]
        public double Result { get; set; }
        
        [StringLength(50)]
        public string Message { get; set; }
    }
}