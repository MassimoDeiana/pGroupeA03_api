using System;

namespace Application.UseCases.ParticipateMeeting.Dtos
{
    public class InputDtoParticipateMeeting
    {
        public int IdMeeting { get; set; }
        public int IdTeacher { get; set; }
        public DateTime DateMeeting { get; set; }
    }
}