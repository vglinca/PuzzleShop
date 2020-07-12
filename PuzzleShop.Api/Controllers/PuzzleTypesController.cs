using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Models.PuzzleTypes;
using PuzzleShop.Core;
using PuzzleShop.Core.Commands.PuzzleTypes;
using PuzzleShop.Core.Dtos.PuzzleTypes;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.PuzzleTypes;

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    public class PuzzleTypesController : BaseController
    {
        private readonly IMediator _mediator;

        public PuzzleTypesController(IMapper mapper, IMediator mediator) : base(mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuzzleTypeTableRowDto>>> GetPuzzleTypes()
        {
            var puzzleTypes = await _mediator.Send(new GetPuzzleTypesQuery());
            return Ok(puzzleTypes);
        }

        [HttpGet("{puzzleTypeId}")]
        public async Task<ActionResult<PuzzleTypeDto>> GetPuzzleType(long puzzleTypeId)
        {
            var puzzleType = await _mediator.Send(new GetPuzzleTypeQuery {Id = puzzleTypeId});
            return Ok(puzzleType);
        }

        [HttpGet("puzzleTypeFriendly/{puzzleTypeId}")]
        public async Task<ActionResult<PuzzleTypeTableRowDto>> GetPuzzleTypeFriendly(long puzzleTypeId)
        {
            var puzzleType = await _mediator.Send(new GetFriendlyPuzzleTypeQuery {Id = puzzleTypeId});
            return Ok(puzzleType);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost]
        public async Task<ActionResult<PuzzleTypeDto>> AddPuzzleType(
            [FromBody] PuzzleTypeCreateModel puzzleTypeForCreationModel)
        {
            var command = _mapper.Map<AddPuzzleTypeCommand>(puzzleTypeForCreationModel);
            var puzzleType = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPuzzleType), new {puzzleTypeId = puzzleType.Id}, puzzleType);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPut("{puzzleTypeId}")]
        public async Task<IActionResult> UpdatePuzzleType(long puzzleTypeId,
            [FromBody] PuzzleTypeUpdateModel puzzleTypeForUpdateModel)
        {
            var command = _mapper.Map<UpdatePuzzleTypeCommand>(puzzleTypeForUpdateModel);
            command.PuzzleTypeId = puzzleTypeId;
            await _mediator.Send(command);
            return NoContent();
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{puzzleTypeId}")]
        public async Task<IActionResult> DeletePuzzleType(long puzzleTypeId)
        {
            await _mediator.Send(new DeletePuzzleTypeCommand {Id = puzzleTypeId});
            return NoContent();
        }
    }
}