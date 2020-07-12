using AutoMapper;
using PuzzleShop.Api.Models.Images;
using PuzzleShop.Core.Commands.Images;
using PuzzleShop.Core.Dtos.Images;

namespace PuzzleShop.Api.MappingProfiles.Images
{
    public class ImagesProfile : Profile
    {
        public ImagesProfile()
        {
            CreateMap<ImageDto, ImageModel>();
            CreateMap<ImageUpdateModel, AddImageCommand>();
        }
    }
}