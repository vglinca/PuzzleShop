using AutoMapper;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Color, ColorForCreateDto>().ReverseMap();
        }
    }
}