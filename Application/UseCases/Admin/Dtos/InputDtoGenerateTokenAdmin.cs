using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Admin.Dtos
{
    public class InputDtoGenerateTokenAdmin
    {
        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}