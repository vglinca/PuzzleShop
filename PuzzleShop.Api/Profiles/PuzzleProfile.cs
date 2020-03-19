using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class PuzzleProfile : Profile
    {
        public PuzzleProfile()
        {
            CreateMap<Domain.Entities.Puzzle, Dtos.Puzzles.PuzzleDto>()
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
                        src => src.DifficultyLevel.Title))
                .ForMember(dest => dest.MaterialType,
                    opt => opt.MapFrom(
                        src => src.MaterialType.Title))
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(
                        src => src.Images)).ReverseMap();
            CreateMap<Dtos.Puzzles.PuzzleForCreationDto, Domain.Entities.Puzzle>().ReverseMap();
            CreateMap<Dtos.Puzzles.PuzzleForUpdateDto, Domain.Entities.Puzzle>();
        }
    }
}