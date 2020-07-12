using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Api.Models.Reviews;
using PuzzleShop.Core.Commands.Reviews;
using PuzzleShop.Core.Queries.Reviews;

namespace PuzzleShop.Api.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/{puzzleId}/[controller]")]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		public ReviewsController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews(long puzzleId)
		{
			var reviews = await _mediator.Send(new GetReviewsQuery {PuzzleId = puzzleId});
			return Ok(reviews);
		}

		[HttpPost]
		public async Task<IActionResult> AddReview(long puzzleId, [FromBody] ReviewCreateModel review)
		{
			var command = _mapper.Map<AddReviewCommand>(review);
			command.PuzzleId = puzzleId;
			await _mediator.Send(command);
			return Ok();
		}
	}
}
