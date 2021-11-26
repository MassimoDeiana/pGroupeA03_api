using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Services;
using Application.UseCases.Teacher;
using Application.UseCases.Teacher.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly UseCaseCreateTeacher _useCaseCreateTeacher;
        private readonly UseCaseGetTeacher _useCaseGetTeacher;
        private readonly UseCaseGenerateTeacher _useCaseGenerateTeacher;
        private readonly UseCaseDeleteTeacher _useCaseDeleteTeacher;
        private readonly TeacherService _teacherService;

        public TeacherController(
            UseCaseCreateTeacher useCaseCreateTeacher,
            UseCaseGetTeacher useCaseGetTeacher,
            UseCaseGenerateTeacher useCaseGenerateTeacher,
            UseCaseDeleteTeacher useCaseDeleteTeacher, 
            TeacherService teacherService) 
        {
            _useCaseCreateTeacher = useCaseCreateTeacher;
            _useCaseGetTeacher = useCaseGetTeacher;
            _useCaseGenerateTeacher = useCaseGenerateTeacher;
            _useCaseDeleteTeacher = useCaseDeleteTeacher;
            _teacherService = teacherService;
        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(InputDtoGenerateTokenTeacher model)
        {
            var response = _teacherService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Mail or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoTeacher>> GetAll()
        {
            return StatusCode(201,_useCaseGetTeacher.Execute());
        }
        
        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoTeacher> GetById(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGenerateTeacher.Execute(
                    new InputDtoGenerateTeacher
                    {
                        IdTeacher = id
                    }));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Teacher not found");
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoTeacher> Create(InputDtoTeacher dto)
        {
            return StatusCode(201, _useCaseCreateTeacher.Execute(dto));
        }
        
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteTeacher.Execute(
                new InputDtoGenerateTeacher {
                    IdTeacher = id
                }))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}