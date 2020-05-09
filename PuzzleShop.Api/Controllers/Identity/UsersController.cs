using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.PaginationModels;

namespace PuzzleShop.Api.Controllers.Identity
{
    public class UsersController : BaseController
    {
        private readonly IUserManagementService _userManagementService;

        public UsersController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost("pagedUsers")]
        public async Task<IActionResult> GetUsers([FromBody] PagedRequest request)
        {
            var pagedUsers = await _userManagementService.GetAllAsync(request);
            return Ok(pagedUsers);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserWithRolesDto>> GetUser(long userId)
        {
            var user = await _userManagementService.GetUserWithRolesAsync(userId);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("plainUser/{userId}")]
        public async Task<ActionResult<UserDto>> GetPlainUser(long userId)
        {
            var user = await _userManagementService.GetPlainUserAsync(userId);
            return Ok(user);
        }

        [RoleAuthorize(AuthorizeRole.Administrator)]
        [HttpPut("manageroles/{userId}")]
        public async Task<IActionResult> EditUserRoles(long userId, [FromBody] IEnumerable<string> roles)
        {
            var rolesAsArray = roles as string[] ?? roles.ToArray();
            await _userManagementService.EditUserRolesAsync(userId, rolesAsArray);

            return NoContent();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("ban/{userId}")]
        public async Task<IActionResult> BanUser(long userId)
        {
            await _userManagementService.BanUser(userId);

            return NoContent();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("unban/{userId}")]
        public async Task<IActionResult> UnbanUser(long userId)
        {
            await _userManagementService.UnbanUser(userId);

            return NoContent();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            await _userManagementService.DeleteUser(userId);
           
            return NoContent();
        }
    }
}