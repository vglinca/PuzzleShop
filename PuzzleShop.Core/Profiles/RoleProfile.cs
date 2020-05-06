using AutoMapper;
using PuzzleShop.Core.Dtos.Roles;
using PuzzleShop.Domain.Entities.Auth;

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