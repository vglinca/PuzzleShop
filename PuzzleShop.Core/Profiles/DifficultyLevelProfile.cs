using AutoMapper;
using PuzzleShop.Core.Dtos.DifficultyLevels;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class DifficultyLevelProfile : Profile
    {
        public DifficultyLevelProfile()
        {
            CreateMap<DifficultyLevel, DifficultyLevelDto>();
        }
    }
}