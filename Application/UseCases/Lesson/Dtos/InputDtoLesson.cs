using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Lesson.Dtos
{
    public class InputDtoLesson
    {
        [StringLength(50)]
        public string Subject { get; set; }
    }
}