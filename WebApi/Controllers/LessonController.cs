using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using Application.Helpers;
using Application.UseCases.Lesson;
using Application.UseCases.Lesson.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly UseCaseCreateLesson _useCaseCreateLesson;
        private readonly UseCaseDeleteLesson _useCaseDeleteLesson;
        private readonly UseCaseGetLesson _useCaseGetLesson;
        private readonly UseCaseGenerateLesson _useCaseGenerateLesson;

        public LessonController(UseCaseCreateLesson useCaseCreateLesson, 
            UseCaseDeleteLesson useCaseDeleteLesson, 
            UseCaseGetLesson useCaseGetLesson, 
            UseCaseGenerateLesson useCaseGenerateLesson)
        {
            _useCaseCreateLesson = useCaseCreateLesson;
            _useCaseDeleteLesson = useCaseDeleteLesson;
            _useCaseGetLesson = useCaseGetLesson;
            _useCaseGenerateLesson = useCaseGenerateLesson;
        }
        
        [Authorize(new [] {Permissions.Teacher, Permissions.Admin, Permissions.Student})]
        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoLesson>> GetAll()
        {
            return StatusCode(201,_useCaseGetLesson.Execute());
        }
        
        [Authorize(new [] {Permissions.Teacher, Permissions.Admin, Permissions.Student})]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoLesson> GetById(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGenerateLesson.Execute(
                    new InputDtoGenerateLesson
                    {
                        IdLesson = id
                    }));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Teacher not found");
            }
        }

        [Authorize(new [] {Permissions.Admin})]
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoLesson> Create(InputDtoLesson dto)
        {
            return StatusCode(201, _useCaseCreateLesson.Execute(dto));
        }
        
        [Authorize(new [] {Permissions.Admin})]
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_useCaseDeleteLesson.Execute(
                    new InputDtoGenerateLesson()
                    {
                        IdLesson = id
                    }))
                {
                    return Ok();
                }
            }
            catch (SqlException e)
            {
                if (e.Errors.Count > 0)
                {
                    throw e.Errors[0].Number switch
                    {
                        547 => new InvalidOperationException("Teacher gave at least one course."),
                        _ => new Exception()
                    };
                }
            }
            return NotFound();
        }
    }
}
