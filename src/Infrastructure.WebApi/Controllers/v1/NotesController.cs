namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
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
    }
}