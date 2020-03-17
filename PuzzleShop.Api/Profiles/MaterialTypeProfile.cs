using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<Domain.Entities.MaterialType, Dtos.MaterialTypes.MaterialTypeDto>().ReverseMap();
            CreateMap<Dtos.MaterialTypes.MaterialTypeForCreationDto, Domain.Entities.MaterialType>().ReverseMap();
        }
    }
}