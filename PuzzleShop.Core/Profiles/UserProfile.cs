using AutoMapper;
using PuzzleShop.Core.Domain.Auth;
using PuzzleShop.Core.Dtos.Users;

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