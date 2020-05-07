using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Images;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Services.Implementation
{
	public class ImageService : IImageService
	{
		private readonly IImageRepository _imagesRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;


		public ImageService(IImageRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_imagesRepository = repository;
			_mapper = mapper;
			_env = env;
		}

		public async Task<IEnumerable<ImageDto>> GetImagesAsync(long puzzleId)
		{
			var images = await _imagesRepository.GetImagesAsync(puzzleId);
			var models = _mapper.Map<IEnumerable<ImageDto>>(images);
			return models;
		}

		public async Task AddImageAsync(long puzzleId, ImageForUpdateDto model)
		{
			var webRootPath = _env.WebRootPath;

			var imagesToAdd = new List<Image>();
			var img = model;
			if (img.Id == null || img.Id <= 0)
			{
				var fileName = Guid.NewGuid().ToString() + ".jpg";
				var filePath = Path.Combine($"{webRootPath}/images/{fileName}");
				imagesToAdd.Add(new Image { FileName = fileName, PuzzleId = puzzleId, Title = img.Title });
				using (var fStream = new FileStream(filePath, FileMode.Create))
				{
					await img.File.CopyToAsync(fStream);
				}
			}
			if (imagesToAdd.Any())
			{
				await _imagesRepository.AddImagesAsync(imagesToAdd);
			}
		}

		public async Task DeleteImagesAsync(long puzzleId, IEnumerable<long> ids)
		{
			var images = await _imagesRepository.GetImagesAsync(puzzleId);
			var webRootPath = _env.WebRootPath;
			foreach (var img in images)
			{
				var filePath = Path.Combine($"{webRootPath}/images/{img.FileName}");
				if (File.Exists(filePath) && ids.Contains(img.Id))
				{
					File.Delete(filePath);
				}
			}

			await _imagesRepository.DeleteImagesAsync(puzzleId, ids);
		}
	}
}
