using System;
using System.ComponentModel.DataAnnotations;
using Application.Helpers;

namespace Application.UseCases.Meeting.Dtos
{
    public class InputDtoMeeting
    {
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }
        
        [Required]
        [Date]
        public DateTime StartTime { get; set; }
        
        [Required]
        [Date]
        public DateTime EndTime { get; set; }
    }
}