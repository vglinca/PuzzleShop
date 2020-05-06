using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.PaginationModels;

namespace PuzzleShop.Api.Controllers.Identity
{
    [Authorize(Roles = "admin")]
    [Authorize(Roles = "moderator")]
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UsersController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpPost("GetPagedUsers")]
        public async Task<IActionResult> GetUsers([FromBody] PagedRequest request)
        {
            var pagedUsers = await _userManagementService.GetAllAsync(request);
            return Ok(pagedUsers);
        }
        
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserWithRolesDto>> GetUser(long userId)
        {
            var user = await _userManagementService.GetUserAsync(userId);
            
            return Ok(user);
        }
        
        [HttpPut("manageroles/{userId}")]
        public async Task<IActionResult> EditUserRoles(long userId, [FromBody] IEnumerable<string> roles)
        {
            var rolesAsArray = roles as string[] ?? roles.ToArray();
            await _userManagementService.EditUserRolesAsync(userId, rolesAsArray);

            return NoContent();
        }

        [HttpPut("ban/{userId}")]
        public async Task<IActionResult> BanUser(long userId)
        {
            await _userManagementService.BanUser(userId);

            return NoContent();
        }
        
        [HttpPut("unban/{userId}")]
        public async Task<IActionResult> UnbanUser(long userId)
        {
            await _userManagementService.UnbanUser(userId);

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            await _userManagementService.DeleteUser(userId);
           
            return NoContent();
        }
    }
}