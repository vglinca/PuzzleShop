using AutoMapper;
using PuzzleShop.Core.Commands.Colors;
using PuzzleShop.Core.Dtos.Images;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<UpdateColorCommand, Image>();
            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}