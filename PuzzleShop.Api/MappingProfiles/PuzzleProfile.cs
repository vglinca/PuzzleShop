using AutoMapper;
using PuzzleShop.Api.Models.Puzzles;
using PuzzleShop.Core.Commands.Puzzles;

namespace PuzzleShop.Api.MappingProfiles
{
    public class PuzzleProfile : Profile
    {
        public PuzzleProfile()
        {
            CreateMap<PuzzleCreateModel, AddPuzzleCommand>();
            CreateMap<PuzzleUpdateModel, UpdatePuzzleCommand>();
        }
    }
}