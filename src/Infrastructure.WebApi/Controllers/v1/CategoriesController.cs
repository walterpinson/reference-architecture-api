namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1
{
    using System;
    using System.Collections.Generic;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1.Bases;
    using CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Validators;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/v1/[controller]")]
    public class CategoriesController : NoteBookBaseController
    {
        private ILogger _logger;
        private readonly INoteTaker _noteTaker;

        public CategoriesController(
            INoteTaker noteTaker,
            ILogger<CategoriesController> logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _noteTaker = noteTaker ?? throw new ArgumentNullException(nameof(noteTaker));
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <response code="200">Categories found and returned</response>
        // GET api/v1/categories

        [HttpGet, Route("")]
        [ProducesResponseType(typeof(IList<CategoryDto>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Get()
        {
            var categoryDtos =  _noteTaker.ListCategories(SecurityContext);
            return Ok(categoryDtos);
        }

        /// <summary>
        /// Get the category identified by the specified ID.
        /// </summary>
        /// <param name="id">Category Identifier.</param>
        /// <response code="200">Category found and returned</response>
        // GET api/v1/categories/:id

        [HttpGet, Route("{id:guid}")]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Get(Guid id)
        {
            var categoryDto = _noteTaker.GetCategoryDetail(SecurityContext, id);
            return Ok(categoryDto);
        }

        /// <summary>
        /// Create new Category.
        /// </summary>
        /// <param name="newCategoryMessage">New Category Message.</param>
        /// <response code="200">Category created.</response>
        // POST api/v1/categories

        [HttpPost, Route("")]
        [ValidateModel]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Post([FromBody]NewCategoryMessage newCategoryMessage)
        {
            var categoryDto = _noteTaker.CreateNewCategory(SecurityContext, newCategoryMessage);
            return CreatedAtAction("Get", new { id = categoryDto.Id }, categoryDto);
        }

        /// <summary>
        /// Change the Category name.
        /// </summary>
        /// <param name="updatedCategory">Category DTO with updated name.</param>
        /// <response code="200">Category updated.</response>
        // PUT api/v1/categories/:id

        [HttpPut, Route("{id:guid}")]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Put(Guid id, [FromBody]CategoryDto updatedCategory)
        {
            var categoryDto = _noteTaker.RenameCategory(SecurityContext, id, updatedCategory.Name);
            return CreatedAtAction("Get", new { id = categoryDto.Id }, categoryDto);
        }

        /// <summary>
        /// Delete the Category.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <response code="200">Category delete.</response>
        // DELETE api/v1/categories/:id

        [HttpDelete, Route("{id:guid}")]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Delete(Guid id)
        {
            _noteTaker.RemoveCategory(SecurityContext, id);
            return NoContent();
        }

        /// <summary>
        /// Get all notes from the given category
        /// </summary>
        /// <param name="id">Category Identifier.</param>
        /// <response code="200">Notes found and returned</response>
        // GET api/v1/categories/{id}/notes

        [HttpGet, Route("{id:guid}/notes")]
        [ProducesResponseType(typeof(IList<NoteDto>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult GetNotesFromCategory(Guid id)
        {
            var noteDtos =_noteTaker.ListCategorizedNotes(SecurityContext, id);
            return Ok(noteDtos);
        }

        /// <summary>
        /// Create note in the given category
        /// </summary>
        /// <param name="id">Category Identifier.</param>
        /// <response code="201">Notes created</response>
        // POST api/v1/categories/{id}/notes

        [HttpPost, Route("{id:guid}/notes")]
        [ValidateModel]
        [ProducesResponseType(typeof(NoteDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult CreateNoteInCategory(Guid id, [FromBody]NewNoteMessage newNoteMessage)
        {
            var noteDto =_noteTaker.TakeCategorizedNote(SecurityContext, id, newNoteMessage);
            return CreatedAtRoute("ReadCategorizedNote", new { noteId = noteDto.Id }, noteDto);
        }

        /// <summary>
        /// Get all notes from the given category
        /// </summary>
        /// <param name="id">Category Identifier.</param>
        /// <param name="noteId">Note Identifier.</param>
        /// <response code="200">Note found and returned</response>
        // GET api/v1/categories/{id}/notes/{id}

        [HttpGet("{id:guid}/notes/{noteId:guid}", Name="ReadCategorizedNote")]
        [ProducesResponseType(typeof(NoteDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult GetNoteFromCategory(Guid id, Guid noteId)
        {
            var noteDto =_noteTaker.ReadCategorizedNote(SecurityContext, id, noteId);
            return Ok(noteDto);
        }


        /// <summary>
        /// Delete the note.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <param name="noteId">Note id.</param>
        /// <response code="200">Note deleted.</response>
        // DELETE api/v1/categories/:id/notes/:id

        [HttpDelete, Route("{id:guid}/notes/{noteId:guid}")]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult DeleteCategorizedNote(Guid id, Guid noteId)
        {
            _noteTaker.RemoveCategorizedNote(SecurityContext, id, noteId);
            return NoContent();
        }

    }
}