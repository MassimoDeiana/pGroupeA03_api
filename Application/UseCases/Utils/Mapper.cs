﻿using Application.UseCases.Meeting.Dtos;
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

                cfg.CreateMap<InputDtoStudent, Domain.Student>();
                cfg.CreateMap<Domain.Student, OutputDtoStudent>();
                
                cfg.CreateMap<InputDtoMeeting, Domain.Meeting>();
                cfg.CreateMap<Domain.Meeting, OutputDtoMeeting>();

            });
            return new AutoMapper.Mapper(config);
        }
    }
}