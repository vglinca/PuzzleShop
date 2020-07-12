using AutoMapper;
using PuzzleShop.Api.Models.PuzzleTypes;
using PuzzleShop.Core.Commands.PuzzleTypes;

namespace PuzzleShop.Api.MappingProfiles
{
    public class PuzzleTypeProfile : Profile
    {
        public PuzzleTypeProfile()
        {
            CreateMap<PuzzleTypeCreateModel, AddPuzzleTypeCommand>();
            CreateMap<PuzzleTypeUpdateModel, UpdatePuzzleTypeCommand>();
        }
    }
}