using AutoMapper;
using PuzzleShop.Core.Dtos.PuzzleTypes;

namespace PuzzleShop.Core.Profiles
{
    public class PuzzleTypeProfile : Profile
    {
        public PuzzleTypeProfile()
        {
            CreateMap<Domain.Entities.PuzzleType, PuzzleTypeDto>()
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(
                        src => src.TypeName))
                .ReverseMap();
            CreateMap<PuzzleTypeForCreationDto, Domain.Entities.PuzzleType>()
                .ForMember(src => src.TypeName,
                    opt => opt.MapFrom(
                        src => src.Title));
        }
    }
}