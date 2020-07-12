using AutoMapper;
using PuzzleShop.Api.Models.MaterialTypes;
using PuzzleShop.Core.Commands.MaterialTypes;

namespace PuzzleShop.Api.MappingProfiles
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<MaterialTypeCreateModel, AddMaterialTypeCommand>();
        }
    }
}