using System;
using System.ComponentModel.DataAnnotations;
using Application.Helpers;
using Application.Helpers.Attributes;

namespace Application.UseCases.Student.Dtos
{
    public class InputDtoStudent
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
        
        [Required]
        public int IdClass { get; set; }
    }
}