using AutoMapper;
using PuzzleShop.Core.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Profiles
{
	public class ReviewProfile : Profile
	{
		public ReviewProfile()
		{
			CreateMap<Domain.Entities.Review, ReviewDto>();
			CreateMap<ReviewForCreationDto, Domain.Entities.Review>();
		}
	}
}
