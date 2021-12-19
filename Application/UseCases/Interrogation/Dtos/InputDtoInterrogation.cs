using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Interrogation.Dtos
{
    public class InputDtoInterrogation
    {
        [Required]
        public int IdTeacher { get; set; }
        
        [Required]
        public int IdLesson { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        public int Total { get; set; }
    }
}