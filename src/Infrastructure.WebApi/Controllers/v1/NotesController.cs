namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Validators;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/v1/[controller]")]
    public class NotesController : Controller
    {
        private ILogger _logger;
        private readonly INoteTaker _noteTaker;

        public NotesController(
            INoteTaker noteTaker,
            ILogger<NotesController> logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _noteTaker = noteTaker ?? throw new ArgumentNullException(nameof(noteTaker));
        }

        /// <summary>
        /// Get all notes from the default group
        /// </summary>
        /// <response code="200">Notes found and returned</response>
        // GET api/v1/notes

        [HttpGet, Route("")]
        [ProducesResponseType(typeof(IList<NoteDto>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Get()
        {
            var noteDtos =_noteTaker.ListNotes();
            return Ok(noteDtos);
        }

        /// <summary>
        /// Get all notes from the default group
        /// </summary>
        /// <param name="id">Note id.</param>
        /// <response code="200">Notes found and returned</response>
        // GET api/v1/notes

        [HttpGet("{id:guid}", Name="GetNote")]
        [ProducesResponseType(typeof(IList<NoteDto>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult GetNote(Guid id)
        {
            var noteDto = _noteTaker.ReadNote(id);
            return Ok(noteDto);
        }

        /// <summary>
        /// Create new Note.
        /// </summary>
        /// <param name="newNoteMessage">New Note Message.</param>
        /// <response code="200">Note created.</response>
        // POST api/v1/notes

        [HttpPost, Route("")]
        [ValidateModel]
        [ProducesResponseType(typeof(NoteDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Post([FromBody]NewNoteMessage newNoteMessage)
        {
            var noteDto = _noteTaker.TakeNote(newNoteMessage);
            return CreatedAtRoute("GetNote", new { id = noteDto.Id }, noteDto);
        }

        /// <summary>
        /// Delete the note.
        /// </summary>
        /// <param name="id">Note id.</param>
        /// <response code="200">Note delete.</response>
        // DELETE api/v1/notes/:id

        [HttpDelete, Route("{id:guid}")]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Delete(Guid id)
        {
            _noteTaker.RemoveNote(id);
            return NoContent();
        }
    }
}