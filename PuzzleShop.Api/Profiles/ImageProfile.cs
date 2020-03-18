using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Domain.Entities.Image, Dtos.Images.ImageDto>().ReverseMap();
        }
    }
}