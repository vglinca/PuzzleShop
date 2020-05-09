using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
	[AllowAnonymous]
	public class PuzzlesController : BaseController
	{
		private readonly IPuzzleService _puzzleService;

		public PuzzlesController(IPuzzleService puzzleService)
		{
			_puzzleService = puzzleService;
		}

		[HttpPost("pagedPuzzles")]
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

		[HttpGet("puzzleFriendly/{puzzleId}")]
		public async Task<ActionResult<PuzzleTableRowDto>> GetPuzzleFriendly(long puzzleId)
		{
			var model = await _puzzleService.GetPuzzleAsync<PuzzleTableRowDto>(puzzleId);
			return Ok(model);
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPost]
		public async Task<ActionResult<PuzzleDto>> AddPuzzle([FromForm] PuzzleForCreationDto puzzleForCreationDto)
		{
			var createdModel = await _puzzleService.AddPuzzleAsync(puzzleForCreationDto);
			return CreatedAtAction(nameof(GetPuzzle), new { puzzleId = createdModel.Id }, createdModel);
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPut("{puzzleId}")]
		public async Task<IActionResult> UpdatePuzzle(long puzzleId, [FromBody] PuzzleForUpdateDto puzzleForUpdateDto)
		{
			await _puzzleService.UpdatePuzzleAsync(puzzleId, puzzleForUpdateDto);
			return NoContent();
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpDelete("{puzzleId}")]
		public async Task<IActionResult> DeletePuzzle(long puzzleId)
		{
			await _puzzleService.DeletePuzzleAsync(puzzleId);
			return NoContent();
		}
	}
}