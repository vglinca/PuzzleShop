using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.DifficultyLevels;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Dtos.Roles;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly IImageRepository<DifficultyLevel> _difflvlRepository;
        private readonly RoleManager<Role> _roleManager;
        private readonly IImageRepository<OrderStatus> _orderStatusRepository; 
        private readonly IMapper _mapper;

        public LookupController(IImageRepository<DifficultyLevel> difflvlRepository, IMapper mapper, RoleManager<Role> roleManager, IImageRepository<OrderStatus> orderStatusRepository)
        {
            _difflvlRepository = difflvlRepository;
            _mapper = mapper;
            _roleManager = roleManager;
            _orderStatusRepository = orderStatusRepository;
        }
        
        [HttpGet("difficultylevels")]
        public async Task<ActionResult<IEnumerable<DifficultyLevelDto>>> GetDifficultyLevels()
        {
            var entities = await _difflvlRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DifficultyLevelDto>>(entities));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(roles));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpGet("orderstatuslist")]
        public async Task<ActionResult<IEnumerable<OrderStatusDto>>> GetOrderStatusList()
        {
            var orderStatusList = await _orderStatusRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<OrderStatusDto>>(orderStatusList));
        }
    }
}