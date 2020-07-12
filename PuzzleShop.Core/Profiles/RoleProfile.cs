using AutoMapper;
using PuzzleShop.Core.Domain.Auth;
using PuzzleShop.Core.Dtos.Roles;

namespace PuzzleShop.Core.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>().ReverseMap();
        }
    }
}