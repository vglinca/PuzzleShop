using AutoMapper;
using Microsoft.Data.SqlClient;
using PuzzleShop.Api.Extensions;

namespace PuzzleShop.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // CreateMap<Dtos.Users.UserForAuthDto, Domain.Entities.User>().ReverseMap();
            CreateMap<Dtos.Users.UserForRegistrationDto, Domain.Entities.Auth.User>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(
                        src => src.BirthDate.GetCurrentAge()));
            CreateMap<Domain.Entities.Auth.User, Dtos.Users.UserDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(
                        src => $"{src.FirstName} {src.LastName}")).ReverseMap();
            CreateMap<Dtos.Users.UserForUpdateDto, Domain.Entities.Auth.User>();
            CreateMap<Domain.Entities.Auth.User, Dtos.Users.UserWithRolesDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(
                        src => $"{src.FirstName} {src.LastName}"));
        }
    }
}