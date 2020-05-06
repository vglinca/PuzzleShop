using AutoMapper;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class PuzzleProfile : Profile
    {
        public PuzzleProfile()
        {
            CreateMap<Puzzle, PuzzleTableRowDto>()
                .ForMember(dest => dest.Manufacturer,
                    opt => opt.MapFrom(
                        src => src.Manufacturer.Name))
                .ForMember(dest => dest.PuzzleType,
                    opt => opt.MapFrom(
                        src => src.PuzzleType.TypeName))
                .ForMember(dest => dest.Color,
                    opt => opt.MapFrom(
                        src => src.Color.Title))
                .ForMember(dest => dest.MaterialType,
                    opt => opt.MapFrom(
                        src => src.MaterialType.Title))
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(
                        src => src.Images));

            CreateMap<Puzzle, PuzzleDto>();

            CreateMap<PuzzleForCreationDto, Puzzle>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<PuzzleForUpdateDto, Puzzle>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());
        }
    }
}