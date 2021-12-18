using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.SchoolClass;
using Application.UseCases.SchoolClass.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [Authorize(new [] {Permissions.Admin,Permissions.Teacher})]
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolClassController : ControllerBase
    {
        private readonly UseCaseCreateSchoolClass _useCaseCreateSchoolClass;
        private readonly UseCaseGetSchoolClass _useCaseGetSchoolClass;
        private readonly UseCaseGenerateSchoolClass _useCaseGenerateSchoolClass;
        private readonly UseCaseDeleteSchoolClass _useCaseDeleteSchoolClass;

        public SchoolClassController(
            UseCaseCreateSchoolClass useCaseCreateSchoolClass, 
            UseCaseGetSchoolClass useCaseGetSchoolClass, 
            UseCaseGenerateSchoolClass useCaseGenerateSchoolClass, 
            UseCaseDeleteSchoolClass useCaseDeleteSchoolClass)
        {
            _useCaseCreateSchoolClass = useCaseCreateSchoolClass;
            _useCaseGetSchoolClass = useCaseGetSchoolClass;
            _useCaseGenerateSchoolClass = useCaseGenerateSchoolClass;
            _useCaseDeleteSchoolClass = useCaseDeleteSchoolClass;
        }

        [HttpGet]
        public ActionResult<List<OutputDtoSchoolClass>> GetAll()
        {
            return _useCaseGetSchoolClass.Execute();
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<OutputDtoSchoolClass> GetById(int id)
        {
            try
            {
                return _useCaseGenerateSchoolClass.Execute(
                    new InputDtoGenerateSchoolClass
                    {
                        IdSchoolClass = id
                    });
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "SchoolClass not found");
            }
            
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoSchoolClass> Create(InputDtoSchoolClass dto)
        {
            return StatusCode(201, _useCaseCreateSchoolClass.Execute(dto));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _useCaseDeleteSchoolClass.Execute(
                    new InputDtoGenerateSchoolClass
                    {
                        IdSchoolClass = id
                    });
                return Ok();
            }
            catch (SqlException e)
            { 
                if(e.Errors.Count > 0)
                {
                    // Ne catch que la première erreur
                    throw e.Errors[0].Number switch
                    {
                        547 => new InvalidOperationException("At least one student remains in the class."),
                        _ => new Exception()
                    };
                }
            }
            return NotFound();
        }
    }
}