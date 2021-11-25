using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Teacher.Dtos
{
    public class InputDtoGenerateTokenTeacher
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}