using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ColorsController: ControllerBase
    {
        private readonly IRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public ColorsController(IRepository<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository ?? throw new ArgumentNullException(nameof(colorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet(Name = "GetColors")]
        public async Task<IActionResult> GetColors()
        {
            var colorsFromRepo = await _colorRepository.GetAllAsync();
            return Ok(_mapper.Map <IEnumerable<ColorDto>>(colorsFromRepo));
        }

        [HttpGet("{colorId}", Name = "GetColor")]
        public async Task<IActionResult> GetColor(long colorId)
        {
            var colorFromRepo = await _colorRepository.FindByIdAsync(colorId);
            return Ok(_mapper.Map<ColorDto>(colorFromRepo));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] ColorForCreateDto colorForCreateDto)
        {
            var colorEntity = _mapper.Map<Color>(colorForCreateDto);
            await _colorRepository.AddEntityAsync(colorEntity);

            return CreatedAtAction(nameof(GetColor), new {colorId = colorEntity.Id}, 
                _mapper.Map<ColorDto>(colorEntity));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPut("{colorId}", Name = "UpdateColor")]
        public async Task<IActionResult> UpdateColor(long colorId, [FromBody] ColorForCreateDto colorForUpdateDto)
        {
            var colorEntity = await _colorRepository.FindByIdAsync(colorId);
            _mapper.Map(colorForUpdateDto, colorEntity);
            await _colorRepository.UpdateEntityAsync(colorEntity);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpDelete("{colorId}", Name = "DeleteColor")]
        public async Task<IActionResult> DeleteColor(long colorId)
        {
            var colorToDelete = await _colorRepository.FindByIdAsync(colorId);
            await _colorRepository.DeleteEntityAsync(colorToDelete);
            return NoContent();
        }
    }
}