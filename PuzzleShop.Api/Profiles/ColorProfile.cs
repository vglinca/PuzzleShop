using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Domain.Entities.Color, Dtos.Colors.ColorDto>().ReverseMap();
            CreateMap<Domain.Entities.Color, Dtos.Colors.ColorForCreateDto>().ReverseMap();
        }
    }
}