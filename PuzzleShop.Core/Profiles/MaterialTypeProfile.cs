using AutoMapper;
using PuzzleShop.Core.Dtos.MaterialTypes;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<MaterialType, MaterialTypeDto>().ReverseMap();
            CreateMap<MaterialTypeForCreationDto, MaterialType>().ReverseMap();
        }
    }
}