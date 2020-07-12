using AutoMapper;
using PuzzleShop.Core.Commands.Colors;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Color, ColorForCreateDto>().ReverseMap();
            CreateMap<AddColorCommand, Color>();
            CreateMap<UpdateColorCommand, Color>();
        }
    }
}