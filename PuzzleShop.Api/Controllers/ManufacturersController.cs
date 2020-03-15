﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PuzzleShop.Api.Dtos.Manufacturers;
using PuzzleShop.Core;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : ControllerBase
    {
        private readonly IRepository<Manufacturer> _manufacturersRepository;
        private readonly IMapper _mapper;
        public ManufacturersController(IRepository<Manufacturer> manufacturersRepository, IMapper mapper)
        {
            _manufacturersRepository = manufacturersRepository ??
                                       throw new ArgumentNullException(nameof(manufacturersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerDto>>> GetManufacturers()
        {
            var manufacturers = await _manufacturersRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers));
        }

        [HttpGet("{manufacturerId}")]
        public async Task<ActionResult<ManufacturerDto>> GetManufacturer(long manufacturerId)
        {
            var manufacturer = await _manufacturersRepository.FindByIdAsync(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ManufacturerDto>(manufacturer));
        }

        [HttpPost]
        public async Task<ActionResult<ManufacturerDto>> AddManufacturer(
           [FromBody] ManufacturerForCreateDto manufacturerForCreateDto)
        {
            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturerForCreateDto);
            await _manufacturersRepository.AddEntityAsync(manufacturerEntity);
            var manufacturerDtoToReturn = _mapper.Map<ManufacturerDto>(manufacturerEntity);
            
            return CreatedAtAction(nameof(GetManufacturer), 
                new {manufacturerId = manufacturerEntity.Id}, manufacturerDtoToReturn);
        }

        [HttpPut("{manufacturerId}")]
        public async Task<IActionResult> UpdateManufacturer(long manufacturerId,
            [FromBody] ManufacturerForUpdateDto manufacturerForUpdateDto)
        {
            var manufacturerFromRepo = await _manufacturersRepository.FindByIdAsync(manufacturerId);
            if (manufacturerFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(manufacturerForUpdateDto, manufacturerFromRepo);
            await _manufacturersRepository.UpdateEntityAsync(manufacturerFromRepo);

            return NoContent();
        }

        [HttpPatch("{manufacturerId}")]
        public async Task<IActionResult> PartiallyUpdateManufacturer(long manufacturerId,
            [FromBody] JsonPatchDocument<ManufacturerForUpdateDto> jsonPatchDocument)
        {
            //retrieve target manufacturer from storage
            var manufacturerFromRepo = await _manufacturersRepository.FindByIdAsync(manufacturerId);
            
            if (manufacturerFromRepo == null)
            {
                return NotFound();
            }
            //convert found manufacturerEntity to manufacturerForUpd DTO
            var manufacturerToPatch = _mapper.Map<ManufacturerForUpdateDto>(manufacturerFromRepo);
            jsonPatchDocument.ApplyTo(manufacturerToPatch, ModelState);
            //validate model before updating the entity
            if (!TryValidateModel(manufacturerToPatch))
            {
                return ValidationProblem(ModelState);
            }
            //convert back to entity updated manufacturerForUpd DTO
            //now manufacturerFromRepo contains updated fields
            _mapper.Map(manufacturerToPatch, manufacturerFromRepo);
            //update entity and save changes
            await _manufacturersRepository.UpdateEntityAsync(manufacturerFromRepo);
            
            return NoContent();
        }

        [HttpDelete("{manufacturerId}")]
        public async Task<IActionResult> DeleteManufacturer(long manufacturerId)
        {
            var entityToDel = await _manufacturersRepository.FindByIdAsync(manufacturerId);
            if (entityToDel == null)
            {
                return NotFound();
            }
            await _manufacturersRepository.DeleteEntityAsync(entityToDel);
            return NoContent();
        }

        //override this to call invalid model state response factory instead of base.ValidationProblem...
        //to execute custom invalid model state response
        [NonAction]
        public override ActionResult ValidationProblem(
            [ActionResultObjectValue]ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            
            return (ActionResult) options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}