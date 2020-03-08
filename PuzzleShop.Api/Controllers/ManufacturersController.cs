using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = "GetManufacturers")]
        public async Task<ActionResult<IEnumerable<ManufacturerDto>>> GetManufacturers()
        {
            var manufacturers = await _manufacturersRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ManufacturerDto>>(manufacturers));
        }

        [HttpGet("{manufacturerId}", Name = "GetManufacturer")]
        public async Task<ActionResult<ManufacturerDto>> GetManufacturer(long manufacturerId)
        {
            var manufacturer = await _manufacturersRepository.FindById(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ManufacturerDto>(manufacturer));
        }

        [HttpPost(Name = "AddManufacturer")]
        public async Task<ActionResult<ManufacturerDto>> AddManufacturer([FromBody] ManufacturerDto manufacturerDto)
        {
            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturerDto);
            await _manufacturersRepository.AddEntity(manufacturerEntity);
            var manufacturerDtoToReturn = _mapper.Map<ManufacturerDto>(manufacturerEntity);
            
            return CreatedAtRoute("GetManufacturer", 
                new {manufacturerEntity.Id}, manufacturerDtoToReturn);
        }

        [HttpDelete("{manufacturerId}")]
        public async Task<IActionResult> DeleteManufacturer(long manufacturerId)
        {
            var entityToDel = await _manufacturersRepository.FindById(manufacturerId);
            if (entityToDel == null)
            {
                return NotFound();
            }
            await _manufacturersRepository.DeleteEntity(entityToDel);
            return NoContent();
        }
    }
}