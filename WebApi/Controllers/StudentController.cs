using System;
using System.Collections.Generic;
using System.Net;
using Application.UseCases.Student;
using Application.UseCases.Student.Dtos;
using Infrastructure.SqlServer.Repositories.Student;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly UseCaseCreateStudent _useCaseCreateStudent;
        private readonly UseCaseGetStudent _useCaseGetStudent;
        private readonly UseCaseGenerateStudent _useCaseGenerateStudent;
        private readonly UseCaseDeleteStudent _useCaseDeleteStudent;

        public StudentController(UseCaseCreateStudent useCaseCreateStudent, UseCaseGetStudent useCaseGetStudent, UseCaseGenerateStudent useCaseGenerateStudent, UseCaseDeleteStudent useCaseDeleteStudent)
        {
            _useCaseCreateStudent = useCaseCreateStudent;
            _useCaseGetStudent = useCaseGetStudent;
            _useCaseGenerateStudent = useCaseGenerateStudent;
            _useCaseDeleteStudent = useCaseDeleteStudent;
        }

        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoStudent>> GetAll()
        {
            return StatusCode(201, _useCaseGetStudent.Execute());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoStudent> GetById(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGenerateStudent.Execute(StudentRepository.ReqDelete,
                    new InputDtoGenerateStudent
                    {
                        IdStudent = id
                    },
                    StudentRepository.ColId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Student not found");
            }
        }

        [HttpPost]
        public ActionResult<OutputDtoStudent> Create([FromBody] InputDtoStudent dto)
        {
            //TODO EXCEPTION IDCLASSE INVALIDE
            return StatusCode(201, _useCaseCreateStudent.Execute(dto));
        }
        
        /*
        [HttpPut]
        [Route("{id:int}")] //on aura un id pour la route
        public ActionResult Update(int id, Student student)
        {
            if (_studentRepository.Update(id, student))
            {
                return Ok();
            }
            return NotFound();
        }
*/
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteStudent.Execute(
                StudentRepository.ReqDelete,
                new InputDtoGenerateStudent {
                    IdStudent = id
                },
                StudentRepository.ColId)) 
            {
                return Ok();
            }

            return NotFound();
        }
    }
    
}