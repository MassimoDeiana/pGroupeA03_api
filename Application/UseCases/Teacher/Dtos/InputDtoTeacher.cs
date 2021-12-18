using System;
using System.ComponentModel.DataAnnotations;
using Application.Helpers;
using Application.Helpers.Attributes;

namespace Application.UseCases.Teacher.Dtos
{
    public class InputDtoTeacher
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        
        [Required]
        [BirthDate]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Mail { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}