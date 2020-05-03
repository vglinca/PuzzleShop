using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
		private readonly IPuzzleRepository _puzzleRepository;
		private readonly IImageRepository _imageRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public PuzzlesController(IMapper mapper, IPuzzleRepository puzzleRepository, IWebHostEnvironment env, IImageRepository imageRepository)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_puzzleRepository = puzzleRepository ?? throw new ArgumentNullException(nameof(puzzleRepository));
			_imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
			_webHostEnvironment = env;
		}

		[HttpPost(nameof(GetPuzzles))]
		public async Task<ActionResult<IEnumerable<PuzzleTableRowDto>>> GetPuzzles([FromBody] PagedRequest pagedRequest)
		{
			var puzzlesPagedResponse = await _puzzleRepository.GetAllAsync(pagedRequest, _mapper);
			return Ok(puzzlesPagedResponse);
		}

		[HttpGet("{puzzleId}")]
		public async Task<ActionResult<PuzzleDto>> GetPuzzle(long puzzleId)
		{
			var puzzle = await _puzzleRepository.FindByIdAsync(puzzleId);
			var model = _mapper.Map<PuzzleDto>(puzzle);
			return Ok(model);
		}

		[HttpGet("getPuzzleFriendly/{puzzleId}")]
		public async Task<ActionResult<PuzzleTableRowDto>> GetPuzzleFriendly(long puzzleId)
		{
			var puzzle = await _puzzleRepository.FindByIdAsync(puzzleId);
			var model = _mapper.Map<PuzzleTableRowDto>(puzzle);
			return Ok(model);
		}

		[Authorize(Roles = "admin")]
		[Authorize(Roles = "moderator")]
		[HttpPost]
		public async Task<ActionResult<PuzzleDto>> AddPuzzle([FromForm]PuzzleForCreationDto puzzleForCreationDto)
		{
			var entityToAdd = _mapper.Map<Puzzle>(puzzleForCreationDto);
			entityToAdd.Images = new List<Image>();

			var webRootPath = _webHostEnvironment.WebRootPath;

			var i = 1;
			foreach (var img in puzzleForCreationDto.Images)
			{
				var fileName = Guid.NewGuid().ToString() + ".jpg";
				var filePath = Path.Combine($"{webRootPath}/images/{fileName}");
				entityToAdd.Images.Add(new Image { FileName = fileName, Title = $"{entityToAdd.Name}-img{i++}" });
				using (var fStream = new FileStream(filePath, FileMode.Create))
				{
					await img.CopyToAsync(fStream);
				}
			}

			await _puzzleRepository.AddEntityAsync(entityToAdd);
			var model = _mapper.Map<PuzzleDto>(entityToAdd);
			return CreatedAtAction(nameof(GetPuzzle), new { puzzleId = entityToAdd.Id }, model);
		}

		[Authorize(Roles = "admin")]
		[Authorize(Roles = "moderator")]
		[HttpPut("{puzzleId}")]
		public async Task<IActionResult> UpdatePuzzle(long puzzleId, [FromBody] PuzzleForUpdateDto puzzleForUpdateDto)
		{
			var puzzleToEdit = await _puzzleRepository.FindByIdAsync(puzzleId);
			_mapper.Map(puzzleForUpdateDto, puzzleToEdit);

			await _puzzleRepository.UpdateEntityAsync(puzzleToEdit);
			return NoContent();
		}

		[Authorize(Roles = "admin")]
		[Authorize(Roles = "moderator")]
		[HttpDelete("{puzzleId}")]
		public async Task<IActionResult> DeletePuzzle(long puzzleId)
		{
			var images = await _imageRepository.GetImagesAsync(puzzleId);
			var webRootPath = _webHostEnvironment.WebRootPath;
			foreach (var img in images)
			{
				var filePath = Path.Combine($"{webRootPath}/images/{img.FileName}");
				if (System.IO.File.Exists(filePath))
				{
					System.IO.File.Delete(filePath);
				}
			}

			var puzzleToDelete = await _puzzleRepository.FindByIdAsync(puzzleId);
			await _puzzleRepository.DeleteEntityAsync(puzzleToDelete);
			
			return NoContent();
		}
	}
}