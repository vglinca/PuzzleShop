using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Images;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Controllers
{
	[AllowAnonymous]
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

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPost(nameof(AddImages))]
		public async Task<IActionResult> AddImages(long puzzleId, [FromForm] ImageForUpdateDto imageModel)
		{
			await _imageService.AddImageAsync(puzzleId, imageModel);

			return Ok();
		}

		[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
		[HttpPost(nameof(DeleteImages))]
		public async Task<IActionResult> DeleteImages(long puzzleId, [FromBody] IEnumerable<long> ids)
		{
			await _imageService.DeleteImagesAsync(puzzleId, ids);
			
			return NoContent();
		}
	}
}
