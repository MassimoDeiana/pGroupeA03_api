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
    [Authorize(new [] {Permissions.Teacher,Permissions.Admin})]
    [ApiController]
    [Route("api/[controller]")]
    public class InterrogationController : ControllerBase
    {
        private readonly UseCaseCreateInterrogation _useCaseCreateInterrogation;
        private readonly UseCaseGetInterrogation _useCaseGetInterrogation;
        private readonly UseCaseGenerateInterrogation _useCaseGenerateInterrogation;
        private readonly UseCaseDeleteInterrogation _useCaseDeleteInterrogation;

        public InterrogationController(
            UseCaseCreateInterrogation useCaseCreateInterrogation, 
            UseCaseGetInterrogation useCaseGetInterrogation, 
            UseCaseGenerateInterrogation useCaseGenerateInterrogation, 
            UseCaseDeleteInterrogation useCaseDeleteInterrogation)
        {
            _useCaseCreateInterrogation = useCaseCreateInterrogation;
            _useCaseGetInterrogation = useCaseGetInterrogation;
            _useCaseGenerateInterrogation = useCaseGenerateInterrogation;
            _useCaseDeleteInterrogation = useCaseDeleteInterrogation;
        }
        
        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoInterrogation>> GetAll()
        {
            return StatusCode(201,_useCaseGetInterrogation.Execute());
        }
        
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
                throw new HttpListenerException(404, "Interogation not found");
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoInterrogation> Create(InputDtoInterrogation dto)
        {
            return StatusCode(201, _useCaseCreateInterrogation.Execute(dto));
        }

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