using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Api.Services.Implementation
{
	public class PuzzleService : IPuzzleService
	{
		private readonly IPuzzleRepository _puzzleRepository;
		private readonly IImageRepository _imageRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public PuzzleService(IPuzzleRepository puzzleRepository, 
							IImageRepository imageRepository, 
							IMapper mapper, 
							IWebHostEnvironment webHostEnvironment)
		{
			_puzzleRepository = puzzleRepository;
			_imageRepository = imageRepository;
			_mapper = mapper;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<PagedResponse<PuzzleTableRowDto>> GetPuzzlesAsync(PagedRequest request)
		{
			var puzzlesPaged = await _puzzleRepository.GetAllAsync(request, _mapper);
			return puzzlesPaged;
		}
		public async Task<TDto> GetPuzzleAsync<TDto>(long puzzleId) where TDto : PuzzleBaseDto
		{
			var puzzle = await _puzzleRepository.FindByIdAsync(puzzleId);
			var model = _mapper.Map<TDto>(puzzle);
			return model;
		}

		public async Task<PuzzleDto> AddPuzzleAsync(PuzzleForCreationDto puzzle)
		{
			var entityToAdd = _mapper.Map<Puzzle>(puzzle);
			entityToAdd.Images = new List<Image>();

			var webRootPath = _webHostEnvironment.WebRootPath;

			var i = 1;
			foreach (var img in puzzle.Images)
			{
				var fileName = Guid.NewGuid() + ".jpg";
				var filePath = Path.Combine($"{webRootPath}/images/{fileName}");
				entityToAdd.Images.Add(new Image { FileName = fileName, Title = $"{entityToAdd.Name}-img{i++}" });
				using (var fStream = new FileStream(filePath, FileMode.Create))
				{
					await img.CopyToAsync(fStream);
				}
			}

			await _puzzleRepository.AddEntityAsync(entityToAdd);
			var model = _mapper.Map<PuzzleDto>(entityToAdd);
			return model;
		}

		public async Task UpdatePuzzleAsync(long puzzleId, PuzzleForUpdateDto puzzle)
		{
			var puzzleToEdit = await _puzzleRepository.FindByIdAsync(puzzleId);
			_mapper.Map(puzzle, puzzleToEdit);

			await _puzzleRepository.UpdateEntityAsync(puzzleToEdit);
		}

		public async Task DeletePuzzleAsync(long puzzleId)
		{
			var images = await _imageRepository.GetImagesAsync(puzzleId);
			var webRootPath = _webHostEnvironment.WebRootPath;
			foreach (var img in images)
			{
				var filePath = Path.Combine($"{webRootPath}/images/{img.FileName}");
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				}
			}

			var puzzleToDelete = await _puzzleRepository.FindByIdAsync(puzzleId);
			await _puzzleRepository.DeleteEntityAsync(puzzleToDelete);
		}
	}
}
