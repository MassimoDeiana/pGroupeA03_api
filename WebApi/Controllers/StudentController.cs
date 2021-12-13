using System;
using System.Collections.Generic;
using System.Net;
using Application.UseCases.Student;
using Application.UseCases.Student.Dtos;
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
        private readonly UseCaseUpdateStudent _useCaseUpdateStudent;
        private readonly UseCaseDeleteStudent _useCaseDeleteStudent;
        private readonly UseCaseGetStudentByClass _useCaseGetStudentByClass;

        public StudentController(UseCaseCreateStudent useCaseCreateStudent, 
            UseCaseGetStudent useCaseGetStudent,
            UseCaseGenerateStudent useCaseGenerateStudent, 
            UseCaseUpdateStudent useCaseUpdateStudent, 
            UseCaseDeleteStudent useCaseDeleteStudent, 
            UseCaseGetStudentByClass useCaseGetStudentByClass)
        {
            _useCaseCreateStudent = useCaseCreateStudent;
            _useCaseGetStudent = useCaseGetStudent;
            _useCaseGenerateStudent = useCaseGenerateStudent;
            _useCaseUpdateStudent = useCaseUpdateStudent;
            _useCaseDeleteStudent = useCaseDeleteStudent;
            _useCaseGetStudentByClass = useCaseGetStudentByClass;
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

        [HttpPost]
        public ActionResult<OutputDtoStudent> Create([FromBody] InputDtoStudent dto)
        {
            //TODO EXCEPTION IDCLASSE INVALIDE
            return StatusCode(201, _useCaseCreateStudent.Execute(dto));
        }
        
        
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

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteStudent.Execute(
                new InputDtoGenerateStudent {
                    IdStudent = id
                })) 
            {
                return Ok();
            }

            return NotFound();
        }
    }
    
}