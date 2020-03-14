using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class DifficultyLevelProfile : Profile
    {
        public DifficultyLevelProfile()
        {
            CreateMap<Domain.Entities.DifficultyLevel, Dtos.DifficultyLevels.DifficultyLevelDto>().ReverseMap();
            CreateMap<Dtos.DifficultyLevels.DifficultyLevelForCreationDto, Domain.Entities.DifficultyLevel>()
                .ReverseMap();
        }
    }
}