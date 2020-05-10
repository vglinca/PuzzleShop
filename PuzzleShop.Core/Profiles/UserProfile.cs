using AutoMapper;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.Extensions;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<User, UserWithRolesDto>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(
                        src => src.BirthDate));
        }
    }
}