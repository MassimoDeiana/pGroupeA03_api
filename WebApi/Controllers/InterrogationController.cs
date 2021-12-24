using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.Interrogation;
using Application.UseCases.Interrogation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterrogationController : ControllerBase
    {
        private readonly UseCaseCreateInterrogation _useCaseCreateInterrogation;
        private readonly UseCaseGetInterrogation _useCaseGetInterrogation;
        private readonly UseCaseGenerateInterrogation _useCaseGenerateInterrogation;
        private readonly UseCaseDeleteInterrogation _useCaseDeleteInterrogation;
        private readonly UseCaseGetInterrogationByTeacher _useCaseGetInterrogationByTeacher;

        public InterrogationController(
            UseCaseCreateInterrogation useCaseCreateInterrogation, 
            UseCaseGetInterrogation useCaseGetInterrogation, 
            UseCaseGenerateInterrogation useCaseGenerateInterrogation, 
            UseCaseDeleteInterrogation useCaseDeleteInterrogation, 
            UseCaseGetInterrogationByTeacher useCaseGetInterrogationByTeacher)
        {
            _useCaseCreateInterrogation = useCaseCreateInterrogation;
            _useCaseGetInterrogation = useCaseGetInterrogation;
            _useCaseGenerateInterrogation = useCaseGenerateInterrogation;
            _useCaseDeleteInterrogation = useCaseDeleteInterrogation;
            _useCaseGetInterrogationByTeacher = useCaseGetInterrogationByTeacher;
        }
        
        [Authorize(new [] {Permissions.Teacher})]
        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoInterrogation>> GetAll()
        {
            return StatusCode(201,_useCaseGetInterrogation.Execute());
        }
        
        [Authorize(new [] {Permissions.Teacher, Permissions.Student})]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoInterrogation> GetById(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGenerateInterrogation.Execute(
                    new InputDtoGenerateInterrogation
                    {
                        IdInterro = id
                    }));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Interrogation not found");
            }
        }
        
        [Authorize(new [] {Permissions.Teacher})]
        [HttpGet]
        [Route("Teacher/{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoInterrogation> GetByTeacher(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGetInterrogationByTeacher.Execute(
                    new InputDtoGenerateInterrogationByTeacher
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

        [Authorize(new [] {Permissions.Teacher})]
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoInterrogation> Create(InputDtoInterrogation dto)
        {
            return StatusCode(201, _useCaseCreateInterrogation.Execute(dto));
        }
        
        [Authorize(new [] {Permissions.Teacher})]
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteInterrogation.Execute(
                new InputDtoGenerateInterrogation() {
                    IdInterro = id
                }))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}