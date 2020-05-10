using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.PaginationModels;

namespace PuzzleShop.Api.Services.Interfaces
{
    public interface IUserManagementService
    {
        Task<PagedResponse<UserWithRolesDto>> GetAllAsync(PagedRequest pagedRequest);
        Task<UserWithRolesDto> GetUserWithRolesAsync(long userId);
        Task<UserDto> GetPlainUserAsync(long userId);
        Task UpdateUserProfileAsync(long userId, UserForUpdateDto model);
        Task EditUserRolesAsync(long userId, IEnumerable<string> roles);
        Task BanUser(long userId);
        Task UnbanUser(long userId);
        Task DeleteUser(long userId);
    }
}