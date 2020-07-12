using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Images;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Api.Models.Images;
using PuzzleShop.Core.Commands.Images;
using PuzzleShop.Core.Queries.Images;

namespace PuzzleShop.Api.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/puzzles/{puzzleId}/[controller]")]
	public class ImagesController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ImagesController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetImages(long puzzleId)
		{
			var images = await _mediator.Send(new GetImagesQuery {PuzzleId = puzzleId});
			var models = _mapper.Map<IEnumerable<ImageModel>>(images);
			return Ok(models);
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPost(nameof(AddImages))]
		public async Task<IActionResult> AddImages(long puzzleId, [FromForm] ImageUpdateModel imageModel)
		{
			var command = _mapper.Map<AddImageCommand>(imageModel);
			command.PuzzleId = puzzleId;
			await _mediator.Send(command);
			return Ok();
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPost(nameof(DeleteImages))]
		public async Task<IActionResult> DeleteImages(long puzzleId, [FromBody] IEnumerable<long> ids)
		{
			await _mediator.Send(new DeleteImagesCommand {PuzzleId = puzzleId, ImageIds = ids});
			return NoContent();
		}
	}
}
