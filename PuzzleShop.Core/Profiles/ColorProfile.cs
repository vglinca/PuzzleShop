using AutoMapper;
using PuzzleShop.Core.Dtos.Colors;

namespace PuzzleShop.Core.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Domain.Entities.Color, ColorDto>().ReverseMap();
            CreateMap<Domain.Entities.Color, ColorForCreateDto>().ReverseMap();
        }
    }
}