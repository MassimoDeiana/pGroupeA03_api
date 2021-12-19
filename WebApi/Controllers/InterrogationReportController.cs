using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.InterrogationReport;
using Application.UseCases.InterrogationReport.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [Authorize(new [] {Permissions.Teacher,Permissions.Admin})]
    [ApiController]
    [Route("api/[controller]")]
    public class InterrogationReportController : ControllerBase
    {
        private readonly UseCaseGetStudentsByInterro _useCaseGenerateResult;

        public InterrogationReportController(UseCaseGetStudentsByInterro useCaseGenerateResult)
        {
            _useCaseGenerateResult = useCaseGenerateResult;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<OutputDtoInterrogationReport>> GetById(int id)
        {
            try
            {
                return _useCaseGenerateResult.Execute(
                    new InputDtoGenerateInterrogationReport
                    {
                        IdInterro = id
                    });
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Interrogation not found");
            }
        }
    }
}