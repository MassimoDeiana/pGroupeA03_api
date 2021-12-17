using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Teacher.Dtos
{
    public class InputDtoGenerateTokenTeacher
    {
        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}