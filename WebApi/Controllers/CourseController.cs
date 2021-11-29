using System;
using System.Collections.Generic;
using System.Net;
using Application.UseCases.Course;
using Application.UseCases.Course.Dtos;
using Infrastructure.SqlServer.Repositories.Course;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CourseController : ControllerBase
    {
        
        private readonly UseCaseCreateCourse _useCaseCreateCourse;
        private readonly UseCaseGetCourse _useCaseGetCourse;
        private readonly ICourseRepository _courseRepository;
        private readonly UseCaseGenerateCourse _useCaseGenerateCourse;
        private readonly UseCaseDeleteCourse _useCaseDeleteCourse;

        public CourseController(ICourseRepository courseRepository,
            UseCaseCreateCourse useCaseCreateCourse,
            UseCaseGetCourse useCaseGetCourse,
            UseCaseGenerateCourse useCaseGenerateCourse,
            UseCaseDeleteCourse useCaseDeleteCourse) 
        {
            _courseRepository = courseRepository;
            _useCaseCreateCourse = useCaseCreateCourse;
            _useCaseGetCourse = useCaseGetCourse;
            _useCaseGenerateCourse = useCaseGenerateCourse;
            _useCaseDeleteCourse = useCaseDeleteCourse;
        }

        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoCourse>> GetAll()
        {
            return StatusCode(201,_useCaseGetCourse.Execute());
        }
        
        
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

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoCourse> Create(InputDtoCourse dto)
        {
            return StatusCode(201, _useCaseCreateCourse.Execute(dto));
        }
        

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