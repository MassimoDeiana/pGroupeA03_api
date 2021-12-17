using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.ParticipateMeeting.Dtos
{
    public class InputDtoParticipateMeeting
    {
        [Required]
        public int IdMeeting { get; set; }
        
        [Required]
        public int IdTeacher { get; set; }
    }
}