using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Dtos.Manufacturers;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Manufacturers;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    public class ManufacturersController : BaseController
    {
        private readonly IRepository<Manufacturer> _manufacturersRepository;
        //private readonly IMapper _mapper;
        public ManufacturersController(IRepository<Manufacturer> manufacturersRepository, 
            IMapper mapper) : base(mapper)
        {
            _manufacturersRepository = manufacturersRepository;
            //_mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetManufacturers()
        {
            var manufacturers = await _manufacturersRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers);
            return Ok(response);
        }

        [HttpGet("{manufacturerId}")]
        public async Task<ActionResult> GetManufacturer(long manufacturerId)
        {
            var manufacturer = await _manufacturersRepository.FindByIdAsync(manufacturerId);
            var response = _mapper.Map<ManufacturerDto>(manufacturer);
            return Ok(response);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost]
        public async Task<ActionResult> AddManufacturer(
           [FromBody] ManufacturerForCreateDto manufacturerForCreateDto)
        {
            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturerForCreateDto);
            await _manufacturersRepository.AddEntityAsync(manufacturerEntity);

            var responseEntity = _mapper.Map<ManufacturerDto>(manufacturerEntity);

            return CreatedAtAction(nameof(GetManufacturer), new {manufacturerId = manufacturerEntity.Id}, responseEntity);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("{manufacturerId}")]
        public async Task<IActionResult> UpdateManufacturer(long manufacturerId,
            [FromBody] ManufacturerForUpdateDto manufacturerForUpdateDto)
        {
            var manufacturerFromRepo = await _manufacturersRepository.FindByIdAsync(manufacturerId);
            
            _mapper.Map(manufacturerForUpdateDto, manufacturerFromRepo);
            await _manufacturersRepository.UpdateEntityAsync(manufacturerFromRepo);

            return Ok();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{manufacturerId}")]
        public async Task<IActionResult> DeleteManufacturer(long manufacturerId)
        {
            var entityToDel = await _manufacturersRepository.FindByIdAsync(manufacturerId);
            await _manufacturersRepository.DeleteEntityAsync(entityToDel);
            
            return NoContent();
        }
    }
}