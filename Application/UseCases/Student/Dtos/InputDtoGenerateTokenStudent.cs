using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Student.Dtos
{
    public class InputDtoGenerateTokenStudent
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}