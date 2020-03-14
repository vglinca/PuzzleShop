using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Domain.Entities.Manufacturer, Dtos.Manufacturers.ManufacturerDto>().ReverseMap();
            CreateMap<Domain.Entities.Manufacturer, Dtos.Manufacturers.ManufacturerForCreateDto>().ReverseMap();
            CreateMap<Domain.Entities.Manufacturer, Dtos.Manufacturers.ManufacturerForUpdateDto>().ReverseMap();
        }
    }
}