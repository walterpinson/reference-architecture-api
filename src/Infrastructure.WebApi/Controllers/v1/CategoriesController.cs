namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/v1/[controller]")]
    public class CategoriesController : Controller
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
        /// Get the categoryt identified by the specified ID.
        /// </summary>
        /// <param name="id">Category Identifier.</param>
        /// <response code="200">Category found and returned</response>
        // GET api/v1/categories/:id

        [HttpGet, Route("{id:guid}")]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Get(Guid id)
        {
            var categoryDto =_noteTaker.GetCategoryDetail(id);
            return Ok(categoryDto);
        }
    }
}