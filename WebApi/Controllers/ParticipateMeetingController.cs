using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.ParticipateMeeting;
using Application.UseCases.ParticipateMeeting.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [Authorize(new [] {Permissions.Teacher,Permissions.Admin})]
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipateMeetingController : ControllerBase
    {
        private readonly UseCaseCreateParticipateMeeting _useCaseCreateParticipateMeeting;
        private readonly UseCaseGetParticipateMeeting _useCaseGetParticipateMeeting;
        private readonly UseCaseGenerateParticipateMeeting _useCaseGenerateParticipateMeeting;
        private readonly UseCaseDeleteParticipateMeeting _useCaseDeleteParticipateMeeting;

        public ParticipateMeetingController(UseCaseCreateParticipateMeeting useCaseCreateParticipateMeeting, 
            UseCaseGetParticipateMeeting useCaseGetParticipateMeeting, 
            UseCaseGenerateParticipateMeeting useCaseGenerateParticipateMeeting, 
            UseCaseDeleteParticipateMeeting useCaseDeleteParticipateMeeting)
        {
            _useCaseCreateParticipateMeeting = useCaseCreateParticipateMeeting;
            _useCaseGetParticipateMeeting = useCaseGetParticipateMeeting;
            _useCaseGenerateParticipateMeeting = useCaseGenerateParticipateMeeting;
            _useCaseDeleteParticipateMeeting = useCaseDeleteParticipateMeeting;
        }
        
        [HttpGet]
        public ActionResult<List<OutputDtoParticipateMeeting>> GetAll()
        {
            return _useCaseGetParticipateMeeting.Execute();
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<OutputDtoParticipateMeeting>> GetById(int id)
        {
            try
            {
                return _useCaseGenerateParticipateMeeting.Execute(
                    new InputDtoGenerateParticipateMeeting
                    {
                        IdMeeting = id
                    });
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "ParticipateMeeting not found");
            }
            
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoParticipateMeeting> Create(InputDtoParticipateMeeting dto)
        {
            return StatusCode(201, _useCaseCreateParticipateMeeting.Execute(dto));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteParticipateMeeting.Execute(
                new InputDtoGenerateParticipateMeeting
                {
                    IdMeeting = id
                }))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}