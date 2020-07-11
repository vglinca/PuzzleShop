using AutoMapper;
using PuzzleShop.Core.Dtos.Images;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}