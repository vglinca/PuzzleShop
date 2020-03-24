﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Dtos.MaterialTypes;
using PuzzleShop.Core;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Api.Controllers
{
    [ApiController]
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
            return Ok(_mapper.Map<IEnumerable<MaterialTypeDto>>(materialTypeEntities));
        }

        [HttpGet("{materialTypeId}")]
        public async Task<ActionResult<MaterialTypeDto>> GetMaterialType(long materialTypeId)
        {
            var materialTypeEntity = await _materialTypeRepository.FindByIdAsync(materialTypeId);
            return Ok(_mapper.Map<MaterialTypeDto>(materialTypeEntity));
        }

        [HttpPost]
        public async Task<ActionResult<MaterialTypeDto>> AddMaterialType(
            [FromBody] MaterialTypeForCreationDto materialTypeForCreationDto)
        {
            var entityToAdd = _mapper.Map<Domain.Entities.MaterialType>(materialTypeForCreationDto);
            await _materialTypeRepository.AddEntityAsync(entityToAdd);

            return CreatedAtAction(nameof(GetMaterialType), new {materialTypeId = entityToAdd.Id},
                _mapper.Map<MaterialTypeDto>(entityToAdd));
        }

        [HttpDelete("{materialTypeId}")]
        public async Task<IActionResult> DeleteMaterialType(long materialTypeId)
        {
            var materialTypeToDel = await _materialTypeRepository.FindByIdAsync(materialTypeId);
            
            await _materialTypeRepository.DeleteEntityAsync(materialTypeToDel);
            return NoContent();
        }
    }
}