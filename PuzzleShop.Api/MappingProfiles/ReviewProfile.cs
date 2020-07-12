using AutoMapper;
using PuzzleShop.Api.Models.Reviews;
using PuzzleShop.Core.Commands.Reviews;

namespace PuzzleShop.Api.MappingProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewCreateModel, AddReviewCommand>();
        }
    }
}