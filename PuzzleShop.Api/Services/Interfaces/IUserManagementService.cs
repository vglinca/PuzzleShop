using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Api.Dtos.Users;

namespace PuzzleShop.Api.Services.Interfaces
{
    public interface IUserManagementService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserWithRolesDto> GetUser(long userId);
        Task EditUserRoles(long userId, IEnumerable<string> roles);
        Task BanUser(long userId);
        Task UnbanUser(long userId);
        Task DeleteUser(long userId);
    }
}