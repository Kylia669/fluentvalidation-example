using FluentValidationExample.Abstractions;
using FluentValidationExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Controllers
{
    public class ItemController : ControllerBase
	{
		private readonly IService _service;

		public ItemController(IService service)
		{
			_service = service;
		}

		[HttpPost("items")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
		[HttpPost]
		public async Task<ObjectResult> CreateAsync([FromBody] CreateRequest request)
		{
			var response = await this._service.CreateAsync(request);
			return this.Ok(response);
		}
	}
}