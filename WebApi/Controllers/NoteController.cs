using System;
using System.Collections.Generic;
using System.Net;
using Application.Helpers;
using Application.Helpers.Attributes;
using Application.UseCases.Note;
using Application.UseCases.Note.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Controllers
{
    [Authorize(new [] {Permissions.Teacher})]
    [ApiController]
    [Route("api/[controller]")]
    
    public class NoteController : ControllerBase
    {
        private readonly UseCaseCreateNote _useCaseCreateNote;
        private readonly UseCaseGetNote _useCaseGetNote;
        private readonly UseCaseGenerateNote _useCaseGenerateNote;
        private readonly UseCaseDeleteNote _useCaseDeleteNote;
        private readonly UseCaseDeleteNoteFromInterrogation _useCaseDeleteNoteFromInterrogation;

        public NoteController(UseCaseCreateNote useCaseCreateNote, 
            UseCaseGetNote useCaseGetNote, 
            UseCaseGenerateNote useCaseGenerateNote, 
            UseCaseDeleteNote useCaseDeleteNote, 
            UseCaseDeleteNoteFromInterrogation useCaseDeleteNoteFromInterrogation)
        {
            _useCaseCreateNote = useCaseCreateNote;
            _useCaseGetNote = useCaseGetNote;
            _useCaseGenerateNote = useCaseGenerateNote;
            _useCaseDeleteNote = useCaseDeleteNote;
            _useCaseDeleteNoteFromInterrogation = useCaseDeleteNoteFromInterrogation;
        }
        
        [Authorize(new [] {Permissions.Teacher, Permissions.Student})]
        [HttpGet]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoNote>> GetAll()
        {
            return StatusCode(201,_useCaseGetNote.Execute());
        }
        
        [Authorize(new [] {Permissions.Student, Permissions.Teacher})]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(201)]
        public ActionResult<List<OutputDtoNote>> GetById(int id)
        {
            try
            {
                return _useCaseGenerateNote.Execute(
                    new InputDtoGetNote
                    {
                        IdStudent = id
                    });
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new HttpListenerException(404, "Note not found");
            }
        }

        [Authorize(new [] {Permissions.Teacher})]
        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<OutputDtoNote> Create(InputDtoNote dto)
        {
            return StatusCode(201, _useCaseCreateNote.Execute(dto));
        }
        
        [Authorize(new [] {Permissions.Teacher})]
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_useCaseDeleteNote.Execute(
                new InputDtoGenerateNote
                {
                    IdNote = id
                }))
            {
                return Ok();
            }
            return NotFound();
        }
        
        [HttpDelete]
        [Route("{idInterro:int}/{idStudent:int}")]
        public ActionResult Delete(int idInterro, int idStudent)
        {
            if (_useCaseDeleteNoteFromInterrogation.Execute(
                new InputDtoDeleteNoteFromInterrogation {
                    IdInterro = idInterro,
                    IdStudent = idStudent
                })) 
            {
                return Ok();
            }
            return NotFound();
        }
    }
}