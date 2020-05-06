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
            // CreateMap<Dtos.Users.UserForAuthDto, Domain.Entities.User>().ReverseMap();
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(
                        src => src.BirthDate.GetCurrentAge()));
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(
                        src => $"{src.FirstName} {src.LastName}")).ReverseMap();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserWithRolesDto>();
        }
    }
}