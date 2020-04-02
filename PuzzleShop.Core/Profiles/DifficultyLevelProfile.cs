using AutoMapper;
using PuzzleShop.Core.Dtos.DifficultyLevels;

namespace PuzzleShop.Core.Profiles
{
    public class DifficultyLevelProfile : Profile
    {
        public DifficultyLevelProfile()
        {
            CreateMap<Domain.Entities.DifficultyLevel, DifficultyLevelDto>();
        }
    }
}