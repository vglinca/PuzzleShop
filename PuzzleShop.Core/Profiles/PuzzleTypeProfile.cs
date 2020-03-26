using AutoMapper;
using PuzzleShop.Core.Dtos.PuzzleTypes;

namespace PuzzleShop.Core.Profiles
{
    public class PuzzleTypeProfile : Profile
    {
        public PuzzleTypeProfile()
        {
            CreateMap<Domain.Entities.PuzzleType, PuzzleTypeDto>().ReverseMap();
            CreateMap<PuzzleTypeForCreationDto, Domain.Entities.PuzzleType>().ReverseMap();
        }
    }
}