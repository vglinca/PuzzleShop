using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    public class ColorsController: BaseController
    {
        private readonly IRepository<Color> _colorRepository;
        //private readonly IMapper _mapper;

        public ColorsController(IRepository<Color> colorRepository, IMapper mapper) : base(mapper)
        {
            _colorRepository = colorRepository;
            //_mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            var colorsFromRepo = await _colorRepository.GetAllAsync();
            return Ok(_mapper.Map <IEnumerable<ColorDto>>(colorsFromRepo));
        }

        [HttpGet("{colorId}")]
        public async Task<IActionResult> GetColor(long colorId)
        {
            var colorFromRepo = await _colorRepository.FindByIdAsync(colorId);
            return Ok(_mapper.Map<ColorDto>(colorFromRepo));
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] ColorForCreateDto colorForCreateDto)
        {
            var colorEntity = _mapper.Map<Color>(colorForCreateDto);
            await _colorRepository.AddEntityAsync(colorEntity);

            return CreatedAtAction(nameof(GetColor), new {colorId = colorEntity.Id}, 
                _mapper.Map<ColorDto>(colorEntity));
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("{colorId}")]
        public async Task<IActionResult> UpdateColor(long colorId, [FromBody] ColorForCreateDto colorForUpdateDto)
        {
            var colorEntity = await _colorRepository.FindByIdAsync(colorId);
            _mapper.Map(colorForUpdateDto, colorEntity);
            await _colorRepository.UpdateEntityAsync(colorEntity);
            return Ok();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{colorId}")]
        public async Task<IActionResult> DeleteColor(long colorId)
        {
            var colorToDelete = await _colorRepository.FindByIdAsync(colorId);
            await _colorRepository.DeleteEntityAsync(colorToDelete);
            return NoContent();
        }
    }
}