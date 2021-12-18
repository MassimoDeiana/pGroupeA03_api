using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.Result;
using Application.UseCases.Result.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [Authorize(new [] {Permissions.Student, Permissions.Teacher,Permissions.Admin})]
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {
        private readonly UseCaseGenerateResult _useCaseGenerateResult;

        public ResultController(UseCaseGenerateResult useCaseGenerateResult)
        {
            _useCaseGenerateResult = useCaseGenerateResult;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<List<OutputDtoResult>> GetById(int id)
        {
            try
            {
                return _useCaseGenerateResult.Execute(
                    new InputDtoGenerateResult
                    {
                        IdStudent = id
                    });
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Result not found");
            }
        }
    }
}