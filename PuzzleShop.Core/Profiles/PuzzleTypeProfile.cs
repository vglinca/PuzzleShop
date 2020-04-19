using AutoMapper;
using PuzzleShop.Core.Dtos.PuzzleTypes;

namespace PuzzleShop.Core.Profiles
{
    public class PuzzleTypeProfile : Profile
    {
        public PuzzleTypeProfile()
        {
            CreateMap<Domain.Entities.PuzzleType, PuzzleTypeTableRowDto>()
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(
                        src => src.TypeName))
                .ForMember(dest => dest.DifficultyLevel,
                    opt => opt.MapFrom(
                        src => src.DifficultyLevel.DifficultyLevelId.ToString()));

            CreateMap<Domain.Entities.PuzzleType, PuzzleTypeDto>()
                .ForMember(dest => dest.DifficultyLevelId,
                    opt => opt.MapFrom(
                        src => (long) src.DifficultyLevel.DifficultyLevelId));

            CreateMap<PuzzleTypeForCreationDto, Domain.Entities.PuzzleType>()
                .ForMember(src => src.TypeName,
                    opt => opt.MapFrom(
                        src => src.Title))
                .ForMember(dest => dest.DifficultyLevelId, opt => opt.MapFrom(
                        src => src.DifficultyLevelId));
        }
    }
}