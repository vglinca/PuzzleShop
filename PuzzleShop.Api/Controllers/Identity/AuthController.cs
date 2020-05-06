using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Domain.Entities.Auth;
using System.Linq;

namespace PuzzleShop.Api.Controllers.Identity
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthOptions _authOptions;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ISigningInService _signingInService;

        public AuthController(IOptions<AuthOptions> authOptions, IMapper mapper, 
            SignInManager<User> signInManager, UserManager<User> userManager, ISigningInService signingInService)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _signingInService = signingInService;
            _authOptions = authOptions.Value;
        }
    
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                return Ok();
            }
            return StatusCode(StatusCodes.Status422UnprocessableEntity, result.Errors);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthDto userForAuthDto)
        {   
            var jwtToken = await _signingInService.SignIn(_authOptions, userForAuthDto);
            //HttpContext.Session.SetString("JWToken", jwtToken);
                
            return Ok(new {AccessToken = jwtToken});
        }
        
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //HttpContext.Session.Clear();
            return Ok();
        }
    }
}