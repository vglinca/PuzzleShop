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
    }
}