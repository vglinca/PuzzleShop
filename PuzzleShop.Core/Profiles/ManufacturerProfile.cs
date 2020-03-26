using AutoMapper;
using PuzzleShop.Core.Dtos.Manufacturers;

namespace PuzzleShop.Core.Profiles
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Domain.Entities.Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<Domain.Entities.Manufacturer, ManufacturerForCreateDto>().ReverseMap();
            CreateMap<Domain.Entities.Manufacturer, Api.Dtos.Manufacturers.ManufacturerForUpdateDto>().ReverseMap();
        }
    }
}