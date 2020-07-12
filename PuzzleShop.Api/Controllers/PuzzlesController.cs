using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Models.Puzzles;
using PuzzleShop.Core.Commands.Puzzles;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Queries.Puzzles;

namespace PuzzleShop.Api.Controllers
{
	[AllowAnonymous]
	public class PuzzlesController : BaseController
	{
		private readonly IMediator _mediator;

		public PuzzlesController(IMediator mediator, IMapper mapper) : base(mapper)
		{
			_mediator = mediator;
		}

		[HttpPost("pagedPuzzles")]
		public async Task<ActionResult<IEnumerable<PuzzleTableRowDto>>> GetPuzzles([FromBody] PagedRequest pagedRequest)
		{
			var puzzles = await _mediator.Send(new GetPuzzlesPagedQuery {PagedRequest = pagedRequest});
			return Ok(puzzles);
		}

		[HttpGet("{puzzleId}")]
		public async Task<ActionResult<PuzzleDto>> GetPuzzle(long puzzleId)
		{
			var puzzle = await _mediator.Send(new GetPuzzleQuery {Id = puzzleId});
			return Ok(puzzle);
		}

		[HttpGet("puzzleFriendly/{puzzleId}")]
		public async Task<ActionResult<PuzzleTableRowDto>> GetPuzzleFriendly(long puzzleId)
		{
			var puzzle = await _mediator.Send(new GetFriendlyPuzzleQuery {Id = puzzleId});
			return Ok(puzzle);
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPost]
		public async Task<ActionResult<PuzzleDto>> AddPuzzle([FromForm] PuzzleCreateModel puzzleForCreationModel)
		{
			var command = _mapper.Map<AddPuzzleCommand>(puzzleForCreationModel);
			var puzzle = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetPuzzle), new { puzzleId = puzzle.Id }, puzzle);
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPut("{puzzleId}")]
		public async Task<IActionResult> UpdatePuzzle(long puzzleId, [FromBody] PuzzleUpdateModel puzzleForUpdateModel)
		{
			var command = _mapper.Map<UpdatePuzzleCommand>(puzzleForUpdateModel);
			command.PuzzleId = puzzleId;
			await _mediator.Send(command);
			return Ok();
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpDelete("{puzzleId}")]
		public async Task<IActionResult> DeletePuzzle(long puzzleId)
		{
			await _mediator.Send(new DeletePuzzleCommand {Id = puzzleId});
			return NoContent();
		}
	}
}