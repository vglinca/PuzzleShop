using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PuzzleShop.Api.Dtos.Manufacturers;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Core;
using PuzzleShop.Core.Commands.Manufacturers;
using PuzzleShop.Core.Dtos.Manufacturers;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.Manufacturers;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    public class ManufacturersController : BaseController
    {
        private readonly IMediator _mediator;

        public ManufacturersController(IMapper mapper, IMediator mediator) : base(mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetManufacturers()
        {
            var manufacturers = await _mediator.Send(new GetManufacturersQuery());
            return Ok(manufacturers);
        }

        [HttpGet("{manufacturerId}")]
        public async Task<ActionResult> GetManufacturer(long manufacturerId)
        {
            var manufacturer = await _mediator.Send(new GetManufacturerQuery {Id = manufacturerId});
            return Ok(manufacturer);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost]
        public async Task<ActionResult> AddManufacturer(
           [FromBody] ManufacturerForCreateDto manufacturerForCreateDto)
        {
            var command = _mapper.Map<AddManufacturerCommand>(manufacturerForCreateDto);
            var manufacturer = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetManufacturer), new {manufacturerId = manufacturer.Id}, manufacturer);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("{manufacturerId}")]
        public async Task<IActionResult> UpdateManufacturer(long manufacturerId,
            [FromBody] ManufacturerForUpdateDto manufacturerForUpdateDto)
        {
            var command = _mapper.Map<UpdateManufacturerCommand>(manufacturerForUpdateDto);
            command.Id = manufacturerId;
            await _mediator.Send(command);
            return Ok();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{manufacturerId}")]
        public async Task<IActionResult> DeleteManufacturer(long manufacturerId)
        {
            await _mediator.Send(new DeleteManufacturerCommand {Id = manufacturerId});
            return NoContent();
        }
    }
}