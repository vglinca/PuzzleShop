using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class PuzzleTypeProfile : Profile
    {
        public PuzzleTypeProfile()
        {
            CreateMap<Domain.Entities.PuzzleType, Dtos.PuzzleTypes.PuzzleTypeDto>().ReverseMap();
            CreateMap<Dtos.PuzzleTypes.PuzzleTypeForCreationDto, Domain.Entities.PuzzleType>().ReverseMap();
        }
    }
}