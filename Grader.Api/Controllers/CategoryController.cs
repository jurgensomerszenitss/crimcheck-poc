using Grader.Api.Business.Commands.CategoryCreate;
using Grader.Api.Business.Commands.CategoryDelete;
using Grader.Api.Business.Commands.CategoryImageUpload;
using Grader.Api.Business.Commands.CategoryUpdate;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Maps;
using Grader.Api.Business.Queries.CategoryGet;
using Grader.Api.Business.Queries.CategorySearch;
using Grader.Api.Policies;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Grader.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        /// <summary>
        /// Searches a list of categories
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CategorySearchQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> SearchAsync([FromQuery] CategorySearchQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Get a category
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CategorySearchQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var request = new CategoryGetQuery { Id = id };
            var result = await _mediator.Send(request);
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType(typeof(CategoryCreateCommandResult), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateCommand request)
        {          
            var result = await _mediator.Send(request);
            return Created(new Uri($"/category/{result.Id}", UriKind.Relative), result);
        }

        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost("{id:long}/image")]
        public async Task<IActionResult> UploadImageAsync([FromRoute] long id)
        {
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var command = files[0].Adapt<CategoryImageUploadCommand>();
                command.CategoryId = id;
                await _mediator.Send(command);
                return Created($"{Business.Environment.URI}/media/",null);
            }
            
            return BadRequest();
        }


        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType(typeof(CategoryUpdateCommandResult), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] CategoryUpdateCommand request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Accepted(new Uri($"/category/{result.Id}", UriKind.Relative), result);
        }

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var request = new CategoryDeleteCommand { Id = id };
            var result = await _mediator.Send(request);
            switch (result.Result)
            {
                case DeleteCommandResult.NotAllowed: return Forbid();
                case DeleteCommandResult.NotFound: return NotFound();
            }

            return NoContent();
        }
    }
}
