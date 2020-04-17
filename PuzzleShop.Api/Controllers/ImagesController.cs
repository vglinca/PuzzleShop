using AutoMapper;
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

		[HttpPost]
		public async Task<IActionResult> AddImages(long puzzleId, [FromForm] ImagesCollectionForUpdateDto imagesDtos)
		{
			var webRootPath = _env.WebRootPath;

			var imagesToAdd = new List<Image>();
			foreach (var img in imagesDtos.Images)
			{
				if(img.Id != null || img.Id > 0)
				{
					var fileName = Guid.NewGuid().ToString() + ".jpg";
					var filePath = Path.Combine($"{webRootPath}/images/{fileName}");
					imagesToAdd.Add(new Image { FileName = fileName, PuzzleId = puzzleId, Title = img.Title });
					using (var fStream = new FileStream(filePath, FileMode.Create))
					{
						await img.File.CopyToAsync(fStream);
					}
				}
			}
			await _imagesRepository.AddImagesAsync(imagesToAdd);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteImages(long puzzleId, [FromBody] IEnumerable<long> ids)
		{
			await _imagesRepository.DeleteImagesAsync(puzzleId, ids);
			return NoContent();
		}
	}
}
