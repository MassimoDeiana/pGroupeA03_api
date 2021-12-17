using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Student.Dtos
{
    public class InputDtoGenerateTokenStudent
    {
        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}