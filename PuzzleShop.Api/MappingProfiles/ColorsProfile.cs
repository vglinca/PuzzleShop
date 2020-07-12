using AutoMapper;
using PuzzleShop.Api.Models.Colors;
using PuzzleShop.Core.Commands.Colors;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Core.Queries.Colors;

namespace PuzzleShop.Api.MappingProfiles.Colors
{
    public class ColorsProfile : Profile
    {
        public ColorsProfile()
        {
            CreateMap<ColorCreateModel, AddColorCommand>();
            CreateMap<ColorCreateModel, UpdateColorCommand>();
            CreateMap<ColorDto, ColorModel>().ReverseMap();
        }
    }
}