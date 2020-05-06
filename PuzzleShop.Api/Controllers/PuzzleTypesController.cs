using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.PuzzleTypes;
using PuzzleShop.Domain.Entities;
namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class PuzzleTypesController : ControllerBase
    {
        private readonly IRepository<PuzzleType> _puzzleTypeRepository;
        private readonly IMapper _mapper;

        public PuzzleTypesController(IRepository<PuzzleType> puzzleTypeRepository, IMapper mapper)
        {
            _puzzleTypeRepository = puzzleTypeRepository ?? throw new ArgumentNullException(nameof(puzzleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuzzleTypeTableRowDto>>> GetPuzzleTypes()
        {
            var puzzleTypeEntities = await _puzzleTypeRepository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<PuzzleTypeTableRowDto>>(puzzleTypeEntities);
            return Ok(models);
        }

        [HttpGet("{puzzleTypeId}")]
        public async Task<ActionResult<PuzzleTypeDto>> GetPuzzleType(long puzzleTypeId)
        {
            var puzzleTypeEntity = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            var model = _mapper.Map<PuzzleTypeDto>(puzzleTypeEntity);
            return Ok(model);
        }

        [HttpGet("getPuzzleTypeFriendly/{puzzleTypeId}")]
        public async Task<ActionResult<PuzzleTypeTableRowDto>> GetPuzzleTypeFriendly(long puzzleTypeId)
        {
            var puzzleTypeEntity = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            var model = _mapper.Map<PuzzleTypeTableRowDto>(puzzleTypeEntity);
            return Ok(model);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost]
        public async Task<ActionResult<PuzzleTypeDto>> AddPuzzleType(
            [FromBody] PuzzleTypeForCreationDto puzzleTypeForCreationDto)
        {
            var newPuzzleType = _mapper.Map<Domain.Entities.PuzzleType>(puzzleTypeForCreationDto);
            await _puzzleTypeRepository.AddEntityAsync(newPuzzleType);

            var model = _mapper.Map<PuzzleTypeDto>(newPuzzleType);
            return CreatedAtAction(nameof(GetPuzzleType), new {puzzleTypeId = newPuzzleType.Id}, model);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("{puzzleTypeId}")]
        public async Task<IActionResult> UpdatePuzzleType(long puzzleTypeId,
            [FromBody] PuzzleTypeForCreationDto puzzleTypeForUpdateDto)
        {
            var puzzleTypeFromRepo = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            _mapper.Map(puzzleTypeForUpdateDto, puzzleTypeFromRepo);
            await _puzzleTypeRepository.UpdateEntityAsync(puzzleTypeFromRepo);
            return NoContent();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{puzzleTypeId}")]
        public async Task<IActionResult> DeletePuzzleType(long puzzleTypeId)
        {
            var entityToDel = await _puzzleTypeRepository.FindByIdAsync(puzzleTypeId);
            await _puzzleTypeRepository.DeleteEntityAsync(entityToDel);
            
            return NoContent();
        }
    }
}