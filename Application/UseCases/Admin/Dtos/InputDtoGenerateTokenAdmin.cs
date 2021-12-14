using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Admin.Dtos
{
    public class InputDtoGenerateTokenAdmin
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}