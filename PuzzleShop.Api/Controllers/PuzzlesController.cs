using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class PuzzlesController : ControllerBase
	{
		private readonly IPuzzleService _puzzleService;

		public PuzzlesController(IPuzzleService puzzleService)
		{
			_puzzleService = puzzleService ?? throw new ArgumentNullException(nameof(puzzleService));
		}

		[HttpPost(nameof(GetPuzzles))]
		public async Task<ActionResult<IEnumerable<PuzzleTableRowDto>>> GetPuzzles([FromBody] PagedRequest pagedRequest)
		{
			var puzzlesPagedResponse = await _puzzleService.GetPuzzlesAsync(pagedRequest);
			return Ok(puzzlesPagedResponse);
		}

		[HttpGet("{puzzleId}")]
		public async Task<ActionResult<PuzzleDto>> GetPuzzle(long puzzleId)
		{
			var model = await _puzzleService.GetPuzzleAsync<PuzzleDto>(puzzleId);
			return Ok(model);
		}

		[HttpGet("getPuzzleFriendly/{puzzleId}")]
		public async Task<ActionResult<PuzzleTableRowDto>> GetPuzzleFriendly(long puzzleId)
		{
			var model = await _puzzleService.GetPuzzleAsync<PuzzleTableRowDto>(puzzleId);
			return Ok(model);
		}

		[Authorize(Roles = "admin")]
		[Authorize(Roles = "moderator")]
		[HttpPost]
		public async Task<ActionResult<PuzzleDto>> AddPuzzle([FromForm] PuzzleForCreationDto puzzleForCreationDto)
		{
			var createdModel = await _puzzleService.AddPuzzleAsync(puzzleForCreationDto);
			return CreatedAtAction(nameof(GetPuzzle), new { puzzleId = createdModel.Id }, createdModel);
		}

		[Authorize(Roles = "admin")]
		[Authorize(Roles = "moderator")]
		[HttpPut("{puzzleId}")]
		public async Task<IActionResult> UpdatePuzzle(long puzzleId, [FromBody] PuzzleForUpdateDto puzzleForUpdateDto)
		{
			await _puzzleService.UpdatePuzzleAsync(puzzleId, puzzleForUpdateDto);
			return NoContent();
		}

		[Authorize(Roles = "admin")]
		[Authorize(Roles = "moderator")]
		[HttpDelete("{puzzleId}")]
		public async Task<IActionResult> DeletePuzzle(long puzzleId)
		{
			await _puzzleService.DeletePuzzleAsync(puzzleId);
			return NoContent();
		}
	}
}