using AutoMapper;
using PuzzleShop.Core.Dtos.MaterialTypes;

namespace PuzzleShop.Core.Profiles
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<Domain.Entities.MaterialType, MaterialTypeDto>().ReverseMap();
            CreateMap<MaterialTypeForCreationDto, Domain.Entities.MaterialType>().ReverseMap();
        }
    }
}