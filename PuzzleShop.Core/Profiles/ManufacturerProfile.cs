using AutoMapper;
using PuzzleShop.Api.Dtos.Manufacturers;
using PuzzleShop.Core.Dtos.Manufacturers;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerForCreateDto>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerForUpdateDto>().ReverseMap();
        }
    }
}