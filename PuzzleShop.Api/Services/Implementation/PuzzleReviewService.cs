using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Reviews;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Services.Implementation
{
	public class PuzzleReviewService : IPuzzleReviewService
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Review> _reviewRepository;
		private readonly IPuzzleRepository _puzzleRepository;
		public PuzzleReviewService(IMapper mapper, 
			IRepository<Review> reviewRepository, 
			IPuzzleRepository puzzleRepository)
		{
			_mapper = mapper;
			_reviewRepository = reviewRepository;
			_puzzleRepository = puzzleRepository;
		}

		public async Task<IEnumerable<ReviewDto>> GetAllReviewsAsync(long puzzleId)
		{
			var puzzle = await _puzzleRepository.FindByIdAsync(puzzleId);
			if(puzzle == null)
			{
				throw new EntityNotFoundException($"Puzzle with id {puzzleId} not found.");
			}
			var reviews = await _reviewRepository.GetAllAsync(review => review.PuzzleId == puzzleId);
			var models = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

			return models;
		}
		public async Task AddReviewAsync(long puzzleId, ReviewForCreationDto review)
		{
			var puzzle = await _puzzleRepository.FindByIdAsync(puzzleId);
			if (puzzle == null)
			{
				throw new EntityNotFoundException($"Puzzle with id {puzzleId} not found.");
			}
			var reviewEntity = _mapper.Map<Review>(review);
			puzzle.Reviews.Add(reviewEntity);
			var rating = puzzle.Reviews.Sum(r => r.Rating) / puzzle.Reviews.Count();
			puzzle.Rating = rating;
			await _puzzleRepository.UpdateEntityAsync(puzzle);
		}
	}
}
