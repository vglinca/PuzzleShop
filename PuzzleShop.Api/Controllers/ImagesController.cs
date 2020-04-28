using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Images;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Controllers
{
	[Authorize(Roles = "admin")]
	[Authorize(Roles = "moderator")]
	[ApiController]
	[Route("api/puzzles/{puzzleId}/[controller]")]
	public class ImagesController : ControllerBase
	{
		private readonly IImageService _imageService;

		public ImagesController(IImageService imageService)
		{
			_imageService = imageService;
		}

		[HttpGet]
		public async Task<IActionResult> GetImages(long puzzleId)
		{
			var models = await _imageService.GetImagesAsync(puzzleId);

			return Ok(models);
		}

		[HttpPost(nameof(AddImages))]
		public async Task<IActionResult> AddImages(long puzzleId, [FromForm] ImageForUpdateDto imageModel)
		{
			await _imageService.AddImageAsync(puzzleId, imageModel);

			return Ok();
		}

		[HttpPost(nameof(DeleteImages))]
		public async Task<IActionResult> DeleteImages(long puzzleId, [FromBody] IEnumerable<long> ids)
		{
			await _imageService.DeleteImagesAsync(puzzleId, ids);
			
			return NoContent();
		}
	}
}
