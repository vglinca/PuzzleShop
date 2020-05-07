using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.DifficultyLevels;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Dtos.Roles;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    public class LookupController : BaseController
    {
        private readonly IRepository<DifficultyLevel> _difflvlRepository;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepository<OrderStatus> _orderStatusRepository; 
        //private readonly IMapper _mapper;

        public LookupController(IRepository<DifficultyLevel> difflvlRepository, 
            IMapper mapper, 
            RoleManager<Role> roleManager, 
            IRepository<OrderStatus> orderStatusRepository) : base(mapper)
        {
            _difflvlRepository = difflvlRepository;
            //_mapper = mapper;
            _roleManager = roleManager;
            _orderStatusRepository = orderStatusRepository;
        }
        
        [HttpGet("difficultylevels")]
        public async Task<ActionResult<IEnumerable<DifficultyLevelDto>>> GetDifficultyLevels()
        {
            var entities = await _difflvlRepository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<DifficultyLevelDto>>(entities);
            return Ok(models);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var models = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return Ok(models);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpGet("orderstatuslist")]
        public async Task<ActionResult<IEnumerable<OrderStatusDto>>> GetOrderStatusList()
        {
            var orderStatusList = await _orderStatusRepository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<OrderStatusDto>>(orderStatusList);
            return Ok(models);
        }
    }
}