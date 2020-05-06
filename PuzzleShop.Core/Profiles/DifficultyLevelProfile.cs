using AutoMapper;
using PuzzleShop.Core.Dtos.DifficultyLevels;
using PuzzleShop.Domain.Entities;

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