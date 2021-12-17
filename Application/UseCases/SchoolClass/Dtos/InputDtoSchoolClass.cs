using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.SchoolClass.Dtos
{
    public class InputDtoSchoolClass
    {
        [Required]
        [StringLength(4)]
        public string Name { get; set; }
        
        [Required]
        [Range(1, 7)]
        public byte Year { get; set; }
        
        [Required]
        [Range(1, 30)]
        public int NbStudents { get; set; }
    }
}