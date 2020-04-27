using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.MaterialTypes;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class MaterialTypeController : ControllerBase
    {
        private readonly IRepository<MaterialType> _materialTypeRepository;
        private readonly IMapper _mapper;

        public MaterialTypeController(IRepository<MaterialType> materialTypeRepository, IMapper mapper)
        {
            _materialTypeRepository = materialTypeRepository 
                                      ?? throw new ArgumentNullException(nameof(materialTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialTypeDto>>> GetMaterialTypes()
        {
            var materialTypeEntities = await _materialTypeRepository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<MaterialTypeDto>>(materialTypeEntities);
            return Ok(models);
        }

        [HttpGet("{materialTypeId}")]
        public async Task<ActionResult<MaterialTypeDto>> GetMaterialType(long materialTypeId)
        {
            var materialTypeEntity = await _materialTypeRepository.FindByIdAsync(materialTypeId);
            var model = _mapper.Map<MaterialTypeDto>(materialTypeEntity);
            return Ok(model);
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<ActionResult<MaterialTypeDto>> AddMaterialType(
            [FromBody] MaterialTypeForCreationDto materialTypeForCreationDto)
        {
            var entityToAdd = _mapper.Map<MaterialType>(materialTypeForCreationDto);
            await _materialTypeRepository.AddEntityAsync(entityToAdd);
            var model = _mapper.Map<MaterialTypeDto>(entityToAdd);

            return CreatedAtAction(nameof(GetMaterialType), new {materialTypeId = entityToAdd.Id}, model );
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpDelete("{materialTypeId}")]
        public async Task<IActionResult> DeleteMaterialType(long materialTypeId)
        {
            var materialTypeToDel = await _materialTypeRepository.FindByIdAsync(materialTypeId);
            
            await _materialTypeRepository.DeleteEntityAsync(materialTypeToDel);
            return NoContent();
        }
    }
}