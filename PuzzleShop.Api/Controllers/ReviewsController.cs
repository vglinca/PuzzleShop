using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Controllers
{
	[AllowAnonymous]
	public class ReviewsController : BaseController
	{
		private readonly IPuzzleReviewService _reviewService;
		public ReviewsController(IPuzzleReviewService reviewService)
		{
			_reviewService = reviewService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews(long puzzleId)
		{
			var reviews = await _reviewService.GetAllReviewsAsync(puzzleId);
			return Ok(reviews);
		}

		[HttpPost]
		public async Task<IActionResult> AddReview(long puzzleId, [FromBody] ReviewForCreationDto review)
		{
			await _reviewService.AddReviewAsync(puzzleId, review);
			return Ok();
		}
	}
}
