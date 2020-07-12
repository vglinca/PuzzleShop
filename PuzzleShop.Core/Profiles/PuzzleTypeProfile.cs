using AutoMapper;
using PuzzleShop.Core.Commands.PuzzleTypes;
using PuzzleShop.Core.Dtos.PuzzleTypes;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class PuzzleTypeProfile : Profile
    {
        public PuzzleTypeProfile()
        {
            CreateMap<PuzzleType, PuzzleTypeTableRowDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.TypeName))
                .ForMember(dest => dest.DifficultyLevel, opt => opt.MapFrom(src => src.DifficultyLevel.DifficultyLevelId.ToString()));
            CreateMap<PuzzleType, PuzzleTypeDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.TypeName))
                .ForMember(dest => dest.DifficultyLevelId, opt => opt.MapFrom(src => (long) src.DifficultyLevel.DifficultyLevelId));
            CreateMap<PuzzleTypeForCreationDto, PuzzleType>()
                .ForMember(src => src.TypeName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DifficultyLevelId, opt => opt.MapFrom(src => src.DifficultyLevelId));
            CreateMap<AddPuzzleTypeCommand, PuzzleType>()
                .ForMember(src => src.TypeName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DifficultyLevelId, opt => opt.MapFrom(src => src.DifficultyLevelId));
            CreateMap<UpdatePuzzleTypeCommand, PuzzleType>()
                .ForMember(src => src.TypeName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DifficultyLevelId, opt => opt.MapFrom(src => src.DifficultyLevelId));
        }
    }
}