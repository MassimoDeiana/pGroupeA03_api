using Application.UseCases.Course.Dtos;
using Application.UseCases.Interrogation.Dtos;
using Application.UseCases.Meeting.Dtos;
using Application.UseCases.Note.Dtos;
using Application.UseCases.ParticipateMeeting.Dtos;
using Application.UseCases.Result.Dtos;
using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Student.Dtos;
using Application.UseCases.Teacher.Dtos;
using AutoMapper;

namespace Application.UseCases.Utils
{
    public static class Mapper
    {
        private static AutoMapper.Mapper _instance;

        public static AutoMapper.Mapper GetInstance()
        {
            return _instance ??= CreateMapper();
        }

        private static AutoMapper.Mapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Source, Destination
                cfg.CreateMap<InputDtoSchoolClass, Domain.SchoolClass>();
                cfg.CreateMap<Domain.SchoolClass, OutputDtoSchoolClass>();
                
                cfg.CreateMap<InputDtoTeacher, Domain.Teacher>();
                cfg.CreateMap<Domain.Teacher, OutputDtoTeacher>();

                cfg.CreateMap<InputDtoCourse, Domain.Course>();
                cfg.CreateMap<Domain.Course, OutputDtoCourse>();

                cfg.CreateMap<InputDtoStudent, Domain.Student>();
                cfg.CreateMap<Domain.Student, OutputDtoStudent>();
                
                cfg.CreateMap<InputDtoMeeting, Domain.Meeting>();
                cfg.CreateMap<Domain.Meeting, OutputDtoMeeting>();

                cfg.CreateMap<InputDtoNote, Domain.Note>();
                cfg.CreateMap<Domain.Note, OutputDtoNote>();

                cfg.CreateMap<InputDtoParticipateMeeting, Domain.ParticipateMeeting>();
                cfg.CreateMap<Domain.ParticipateMeeting, OutputDtoParticipateMeeting>();

                cfg.CreateMap<InputDtoInterrogation, Domain.Interrogation>();
                cfg.CreateMap<Domain.Interrogation, OutputDtoInterrogation>();

                cfg.CreateMap<Domain.ResultReport, OutputDtoResult>();

            });
            return new AutoMapper.Mapper(config);
        }
    }
}