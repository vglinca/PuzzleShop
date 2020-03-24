using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Dtos.Users;
using PuzzleShop.Api.Services.Interfaces;

namespace PuzzleShop.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UsersController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return Ok(await _userManagementService.GetAll());
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserWithRolesDto>> GetUser(long userId)
        {
            var user = await _userManagementService.GetUser(userId);
            
            return Ok(user);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPut("manageroles/{userId}")]
        public async Task<IActionResult> EditUserRoles(long userId, [FromBody] IEnumerable<string> roles)
        {
            var rolesAsArray = roles as string[] ?? roles.ToArray();
            await _userManagementService.EditUserRoles(userId, rolesAsArray);

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("ban/{userId}")]
        public async Task<IActionResult> BanUser(long userId)
        {
            await _userManagementService.BanUser(userId);

            return NoContent();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPut("unban/{userId}")]
        public async Task<IActionResult> UnbanUser(long userId)
        {
            await _userManagementService.UnbanUser(userId);

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            await _userManagementService.DeleteUser(userId);
           
            return NoContent();
        }
    }
}