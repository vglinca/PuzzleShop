using AutoMapper;
using PuzzleShop.Core.Dtos.Roles;

namespace PuzzleShop.Core.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Domain.Entities.Auth.Role>().ReverseMap();
        }
    }
}