using AutoMapper;
using Microsoft.Data.SqlClient;
using PuzzleShop.Api.Extensions;

namespace PuzzleShop.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Dtos.Users.UserForAuthDto, Domain.Entities.User>().ReverseMap();
            CreateMap<Dtos.Users.UserForRegistrationDto, Domain.Entities.User>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(
                        src => src.BirthDate.GetCurrentAge()));
            CreateMap<Domain.Entities.User, Dtos.Users.UserDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(
                        src => $"{src.FirstName} {src.LastName}")).ReverseMap();
        }
    }
}