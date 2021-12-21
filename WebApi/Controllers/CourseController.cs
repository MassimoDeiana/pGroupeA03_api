using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.Course;
using Application.UseCases.Course.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    
    public class CourseController : ControllerBase
    {
        private readonly UseCaseCreateCourse _useCaseCreateCourse;
        private readonly UseCaseGetCourse _useCaseGetCourse;
        private readonly UseCaseGenerateCourse _useCaseGenerateCourse;
        private readonly UseCaseDeleteCourse _useCaseDeleteCourse;
        private readonly UseCaseGetCourseByTeacher _useCaseGetCourseByTeacher;

        public CourseController(UseCaseCreateCourse useCaseCreateCourse,
            UseCaseGetCourse useCaseGetCourse,
            UseCaseGenerateCourse useCaseGenerateCourse,
            UseCaseDeleteCourse useCaseDeleteCourse,
            UseCaseGetCourseByTeacher useCaseGetCourseByTeacher) 
        {
            _useCaseCreateCourse = useCaseCreateCourse;
            _useCaseGetCourse = useCaseGetCourse;
            _useCaseGenerateCourse = useCaseGenerateCourse;
            _useCaseDeleteCourse = useCaseDeleteCourse;
            _useCaseGetCourseByTeacher = useCaseGetCourseByTeacher;
        }

        [Authorize(new [] {Permissions.Teacher, Permissions.Admin, Permissions.Student})]
        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoCourse>> GetAll()
        {
            return StatusCode(201,_useCaseGetCourse.Execute());
        }

        [Authorize(new [] {Permissions.Teacher, Permissions.Admin})]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoCourse> GetById(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGenerateCourse.Execute(new InputDtoGenerateCourse
                {
                    IdCourse = id
                }));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Meeting not found");
            }
        }
        
        
        [Authorize(new [] {Permissions.Teacher,Permissions.Admin})]
        [HttpGet]
        [Route("Teacher/{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoCourse> GetByTeacher(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGetCourseByTeacher.Execute(
                    new InputDtoGenerateCourseByTeacher()
                    {
                        IdTeacher = id
                    }));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Interrogation not found");
            }
        }

        [Authorize(new [] {Permissions.Teacher, Permissions.Admin})]
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoCourse> Create(InputDtoCourse dto)
        {
            return StatusCode(201, _useCaseCreateCourse.Execute(dto));
        }
        
        [Authorize(new [] {Permissions.Teacher, Permissions.Admin})]
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteCourse.Execute(new InputDtoGenerateCourse
                {
                    IdCourse = id
                }))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}