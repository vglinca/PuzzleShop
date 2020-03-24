using AutoMapper;

namespace PuzzleShop.Api.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Dtos.Roles.RoleDto, Domain.Entities.Auth.Role>().ReverseMap();
        }
    }
}