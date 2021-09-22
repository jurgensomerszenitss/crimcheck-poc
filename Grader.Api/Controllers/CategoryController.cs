using Grader.Api.Business.Commands;
using Grader.Api.Business.Enums;
using Grader.Api.Business.Queries;
using Grader.Api.Policies;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
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
        [ProducesResponseType(typeof(CategorySearch.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> SearchAsync([FromQuery] CategorySearch.Query request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Get a category
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CategoryGet.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
        {
            var result = await _mediator.Send(new CategoryGet.Query(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize(Policy = PolicyNames.ADMIN)]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCreate.Command request)
        {          
            var result = await _mediator.Send(request);
            return Created(new Uri($"/category/{result}", UriKind.Relative), result);
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
                var file = files.First();

                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                var content = memoryStream.ToArray();

                var command = new CategoryImageUpload.Command ( id,
                    Path.GetFileNameWithoutExtension(file.FileName).ToLower(),
                    Path.GetExtension(file.FileName).ToLower().TrimStart('.'),
                    Guid.NewGuid().ToString(),
                    content);
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
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] CategoryUpdate.Command request)
        {
            var result = await _mediator.Send(request with { Id = id });
            return Accepted(new Uri($"/category/{id}", UriKind.Relative));
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
            var result = await _mediator.Send(new CategoryDelete.Command(id));
            switch (result)
            {
                case DeleteCommandResult.NotAllowed: return Forbid();
                case DeleteCommandResult.NotFound: return NotFound();
            }

            return NoContent();
        }
    }
}
