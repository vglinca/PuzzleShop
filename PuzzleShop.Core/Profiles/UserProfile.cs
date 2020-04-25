using AutoMapper;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.Extensions;

namespace PuzzleShop.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // CreateMap<Dtos.Users.UserForAuthDto, Domain.Entities.User>().ReverseMap();
            CreateMap<UserForRegistrationDto, Domain.Entities.Auth.User>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(
                        src => src.BirthDate.GetCurrentAge()));
            CreateMap<Domain.Entities.Auth.User, UserDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(
                        src => $"{src.FirstName} {src.LastName}")).ReverseMap();
            CreateMap<UserForUpdateDto, Domain.Entities.Auth.User>();
            CreateMap<Domain.Entities.Auth.User, UserWithRolesDto>();
        }
    }
}