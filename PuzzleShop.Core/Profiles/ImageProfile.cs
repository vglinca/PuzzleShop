using AutoMapper;
using PuzzleShop.Core.Dtos.Images;
using PuzzleShop.Domain.Entities;

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