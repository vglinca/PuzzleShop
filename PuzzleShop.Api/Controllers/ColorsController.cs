using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Dtos.Colors;
using PuzzleShop.Core;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [ApiController]
    [Route("api/colors")]
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
        public async Task<ActionResult<IEnumerable<ColorDto>>> GetColors()
        {
            var colorsFromRepo = await _colorRepository.GetAllAsync();
            return Ok(_mapper.Map <IEnumerable<ColorDto>>(colorsFromRepo));
        }

        [HttpGet("{colorId}", Name = "GetColor")]
        public async Task<ActionResult<ColorDto>> GetColor(long colorId)
        {
            var colorFromRepo = await _colorRepository.FindById(colorId);
            if (colorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ColorDto>(colorFromRepo));
        }

        public async Task<ActionResult<ColorDto>> AddColor([FromBody] ColorForCreateDto colorForCreateDto)
        {
            //create new color entity by mapping post dto to it
            var colorEntity = _mapper.Map<Color>(colorForCreateDto);
            await _colorRepository.AddEntity(colorEntity);
            //map created entity to return dto
            var colorDtoToReturn = _mapper.Map<ColorDto>(colorEntity);

            return CreatedAtAction(nameof(GetColor), new {colorId = colorEntity.Id}, colorDtoToReturn);
        }

        [HttpPut("{colorId}", Name = "UpdateColor")]
        public async Task<IActionResult> UpdateColor(long colorId, [FromBody] ColorForCreateDto colorForUpdateDto)
        {
            var colorEntity = await _colorRepository.FindById(colorId);
            if (colorEntity == null)
            {
                return NotFound();
            }

            _mapper.Map<Color>(colorForUpdateDto);
            await _colorRepository.UpdateEntity(colorEntity);
            return NoContent();
        }

        [HttpDelete("{colorId}", Name = "DeleteColor")]
        public async Task<IActionResult> DeleteColor(long colorId)
        {
            var colorToDelete = await _colorRepository.FindById(colorId);
            if (colorToDelete == null)
            {
                return NotFound();
            }

            await _colorRepository.DeleteEntity(colorToDelete);
            return NoContent();
        }
    }
}