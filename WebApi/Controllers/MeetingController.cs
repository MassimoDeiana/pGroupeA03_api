using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.Meeting;
using Application.UseCases.Meeting.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [Authorize(new [] {Permissions.Teacher,Permissions.Admin})]
    [ApiController]
    [Route("api/[controller]")]
    
    public class MeetingController : ControllerBase
    {
        private readonly UseCaseCreateMeeting _useCaseCreateMeeting;
        private readonly UseCaseGetMeeting _useCaseGetMeeting;
        private readonly UseCaseGenerateMeeting _useCaseGenerateMeeting;
        private readonly UseCaseDeleteMeeting _useCaseDeleteMeeting;

        public MeetingController(
            UseCaseCreateMeeting useCaseCreateMeeting,
            UseCaseGetMeeting useCaseGetMeeting,
            UseCaseGenerateMeeting useCaseGenerateMeeting,
            UseCaseDeleteMeeting useCaseDeleteMeeting) 
        {
            _useCaseCreateMeeting = useCaseCreateMeeting;
            _useCaseGetMeeting = useCaseGetMeeting;
            _useCaseGenerateMeeting = useCaseGenerateMeeting;
            _useCaseDeleteMeeting = useCaseDeleteMeeting;
        }

        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoMeeting>> GetAll()
        {
            return StatusCode(201,_useCaseGetMeeting.Execute());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoMeeting> GetById(int id)
        {
            try
            {
                return StatusCode(201, _useCaseGenerateMeeting.Execute(
                    new InputDtoGenerateMeeting
                    {
                        IdMeeting = id
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
        public ActionResult<OutputDtoMeeting> Create(InputDtoMeeting dto)
        {
            return StatusCode(201, _useCaseCreateMeeting.Execute(dto));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteMeeting.Execute(
                new InputDtoGenerateMeeting
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