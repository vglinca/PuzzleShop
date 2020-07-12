using AutoMapper;
using PuzzleShop.Api.Dtos.Manufacturers;
using PuzzleShop.Core.Commands.Manufacturers;
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
            CreateMap<ManufacturerForCreateDto, AddManufacturerCommand>();
            CreateMap<AddManufacturerCommand, Manufacturer>();
            CreateMap<ManufacturerForUpdateDto, UpdateManufacturerCommand>();
            CreateMap<UpdateManufacturerCommand, Manufacturer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}