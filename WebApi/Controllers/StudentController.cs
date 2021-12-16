using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using Application.Helpers;
using Application.Services;
using Application.UseCases.Student;
using Application.UseCases.Student.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [Authorize(new [] {Permissions.Admin})]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly UseCaseCreateStudent _useCaseCreateStudent;
        private readonly UseCaseGetStudent _useCaseGetStudent;
        private readonly UseCaseGenerateStudent _useCaseGenerateStudent;
        private readonly UseCaseUpdateStudent _useCaseUpdateStudent;
        private readonly UseCaseDeleteStudent _useCaseDeleteStudent;
        private readonly UseCaseGetStudentByClass _useCaseGetStudentByClass;
		private readonly IStudentService _studentService;

        public StudentController(UseCaseCreateStudent useCaseCreateStudent, 
            UseCaseGetStudent useCaseGetStudent,
            UseCaseGenerateStudent useCaseGenerateStudent, 
            UseCaseUpdateStudent useCaseUpdateStudent, 
            UseCaseDeleteStudent useCaseDeleteStudent, 
            UseCaseGetStudentByClass useCaseGetStudentByClass,
			IStudentService studentService)
        {
            _useCaseCreateStudent = useCaseCreateStudent;
            _useCaseGetStudent = useCaseGetStudent;
            _useCaseGenerateStudent = useCaseGenerateStudent;
            _useCaseUpdateStudent = useCaseUpdateStudent;
            _useCaseDeleteStudent = useCaseDeleteStudent;
            _useCaseGetStudentByClass = useCaseGetStudentByClass;
			_studentService = studentService;
        }
        
        [HttpPost("authenticate")]
        public IActionResult Authenticate(InputDtoGenerateTokenStudent model)
        {
            var response = _studentService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Mail or password is incorrect" });

            return Ok(response);
        }
        
        [Authorize(new []{Permissions.Teacher, Permissions.Admin})]
        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoStudent>> GetAll()
        {
            return StatusCode(201, _useCaseGetStudent.Execute());
        }
        
        [Authorize(new [] {Permissions.Student, Permissions.Teacher, Permissions.Admin})]
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoStudent> GetById(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGenerateStudent.Execute(
                    new InputDtoGenerateStudent
                    {
                        IdStudent = id
                    }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Student not found");
            }
        }
        
        [Authorize(new [] {Permissions.Teacher,Permissions.Admin})]
        [HttpGet]
        [Route("class/{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoStudent>> GetByClass(int id)
        {
            try
            {
                return _useCaseGetStudentByClass.Execute(
                    new InputDtoGenerateListStudent()
                    {
                        IdClass = id
                    });
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Note not found");
            }
        }

        [Authorize(new [] {Permissions.Admin})]
        [HttpPost]
        public ActionResult<OutputDtoStudent> Create([FromBody] InputDtoStudent dto)
        {
            //TODO EXCEPTION IDCLASSE INVALIDE
            return StatusCode(201, _useCaseCreateStudent.Execute(dto));
        }
        
        [Authorize(new [] {Permissions.Student,Permissions.Admin})]
        [HttpPut]
        [Route("{id:int}/{idClass:int}")] //on aura un id pour la route
        public ActionResult Update(int id, int idClass)
        {
            if (_useCaseUpdateStudent.Execute(id, idClass))
            {
                return Ok();
            }

            return NotFound();
        }

        [Authorize(new [] {Permissions.Admin})]
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_useCaseDeleteStudent.Execute(
                    new InputDtoGenerateStudent {
                        IdStudent = id
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
                        547 => new InvalidOperationException("Can't delete that student."),
                        _ => new Exception()
                    };
                }
            }
        

            return NotFound();
        }
    }
    
}