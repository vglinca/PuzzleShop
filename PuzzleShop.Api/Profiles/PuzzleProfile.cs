using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class PuzzleProfile : Profile
    {
        public PuzzleProfile()
        {
            CreateMap<Domain.Entities.Puzzle, Dtos.Puzzles.PuzzleDto>().ReverseMap();
            CreateMap<Dtos.Puzzles.PuzzleForCreationDto, Domain.Entities.Puzzle>().ReverseMap();
        }
    }
}