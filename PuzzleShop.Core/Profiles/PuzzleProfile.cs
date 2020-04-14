using AutoMapper;
using PuzzleShop.Core.Dtos.Puzzles;

namespace PuzzleShop.Core.Profiles
{
    public class PuzzleProfile : Profile
    {
        public PuzzleProfile()
        {
            CreateMap<Domain.Entities.Puzzle, PuzzleDto>()
                .ForMember(dest => dest.Manufacturer,
                    opt => opt.MapFrom(
                        src => src.Manufacturer.Name))
                .ForMember(dest => dest.PuzzleType,
                    opt => opt.MapFrom(
                        src => src.PuzzleType.TypeName))
                .ForMember(dest => dest.Color,
                    opt => opt.MapFrom(
                        src => src.Color.Title))
                .ForMember(dest => dest.DifficultyLevel,
                    opt => opt.MapFrom(
                        src => src.DifficultyLevel.DifficultyLevelId.ToString()))
                .ForMember(dest => dest.MaterialType,
                    opt => opt.MapFrom(
                        src => src.MaterialType.Title))
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(
                        src => src.Images)).ReverseMap();
            CreateMap<PuzzleForCreationDto, Domain.Entities.Puzzle>()
                .ForMember(dest => dest.DifficultyLevelId,
                    opt => opt.MapFrom(
                        src => src.DifficultyLevelId));
            CreateMap<PuzzleForUpdateDto, Domain.Entities.Puzzle>();
        }
    }
}