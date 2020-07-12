using AutoMapper;
using PuzzleShop.Core.Commands.Reviews;
using PuzzleShop.Core.Dtos.Reviews;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
	public class ReviewProfile : Profile
	{
		public ReviewProfile()
		{
			CreateMap<Review, ReviewDto>();
			CreateMap<ReviewForCreationDto, Review>();
			CreateMap<AddReviewCommand, Review>();
		}
	}
}
