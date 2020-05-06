using AutoMapper;
using PuzzleShop.Core.Dtos.Reviews;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Profiles
{
	public class ReviewProfile : Profile
	{
		public ReviewProfile()
		{
			CreateMap<Review, ReviewDto>();
			CreateMap<ReviewForCreationDto, Review>();
		}
	}
}
