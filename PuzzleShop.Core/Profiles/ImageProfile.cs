using AutoMapper;
using PuzzleShop.Core.Dtos.Images;

namespace PuzzleShop.Core.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Domain.Entities.Image, ImageDto>().ReverseMap();
        }
    }
}