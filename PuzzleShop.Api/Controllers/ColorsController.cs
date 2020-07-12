using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Models.Colors;
using PuzzleShop.Core.Commands.Colors;
using PuzzleShop.Core.Queries.Colors;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    public class ColorsController: BaseController
    {
        private readonly IMediator _mediator;

        public ColorsController(IMapper mapper, IMediator mediator) : base(mapper)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            var colors = await _mediator.Send(new GetColorsQuery());
            return Ok(_mapper.Map<IEnumerable<ColorModel>>(colors));
        }

        [HttpGet("{colorId}")]
        public async Task<IActionResult> GetColor(long colorId)
        {
            var color = await _mediator.Send(new GetSingleColorQuery {Id = colorId});
            return Ok(_mapper.Map<ColorModel>(color));
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] ColorCreateModel colorForCreateModel)
        {
            var command = _mapper.Map<AddColorCommand>(colorForCreateModel);
            var color = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetColor), new {colorId = color.Id}, color);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("{colorId}")]
        public async Task<IActionResult> UpdateColor(long colorId, [FromBody] ColorCreateModel colorForUpdateModel)
        {
            var command = _mapper.Map<UpdateColorCommand>(colorForUpdateModel);
            command.Id = colorId;
            await _mediator.Send(command);
            return Ok();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{colorId}")]
        public async Task<IActionResult> DeleteColor(long colorId)
        {
            await _mediator.Send(new DeleteColorCommand {Id = colorId});
            return NoContent();
        }
    }
}