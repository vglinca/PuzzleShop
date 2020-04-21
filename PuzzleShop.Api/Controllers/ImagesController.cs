using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
	[AllowAnonymous]
	[ApiController]
	[Route("api/puzzles/{puzzleId}/[controller]")]
	public class ImagesController : ControllerBase
	{
		private readonly IImageRepository _imagesRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;

		public ImagesController(IImageRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_imagesRepository = repository;
			_mapper = mapper;
			_env = env;		
		}

		[HttpGet]
		public async Task<IActionResult> GetImages(long puzzleId)
		{
			var images = await _imagesRepository.GetImagesAsync(puzzleId);
			var imgDtos = _mapper.Map<IEnumerable<ImageDto>>(images);
			return Ok(imgDtos);
		}

		[HttpPost(nameof(AddImages))]
		public async Task<IActionResult> AddImages(long puzzleId, [FromForm] ImageForUpdateDto imagesDtos)
		{
			var webRootPath = _env.WebRootPath;

			var imagesToAdd = new List<Image>();
			var img = imagesDtos;
			//foreach (var img in imagesDtos)
			//{
				if(img.Id == null || img.Id <= 0)
				{
					var fileName = Guid.NewGuid().ToString() + ".jpg";
					var filePath = Path.Combine($"{webRootPath}/images/{fileName}");
					imagesToAdd.Add(new Image { FileName = fileName, PuzzleId = puzzleId, Title = img.Title });
					using (var fStream = new FileStream(filePath, FileMode.Create))
					{
						await img.File.CopyToAsync(fStream);
					}
				}
			//}
			if (imagesToAdd.Any())
			{
				await _imagesRepository.AddImagesAsync(imagesToAdd);
			}
			return Ok();
		}

		[HttpPost(nameof(DeleteImages))]
		public async Task<IActionResult> DeleteImages(long puzzleId, [FromBody] IEnumerable<long> ids)
		{
			var images = await _imagesRepository.GetImagesAsync(puzzleId);
			var webRootPath = _env.WebRootPath;
			foreach (var img in images)
			{
				var filePath = Path.Combine($"{webRootPath}/images/{img.FileName}");
				if (System.IO.File.Exists(filePath) && ids.Contains(img.Id))
				{
					System.IO.File.Delete(filePath);
				}
			}

			await _imagesRepository.DeleteImagesAsync(puzzleId, ids);
			
			return NoContent();
		}
	}
}
