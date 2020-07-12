using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Models.MaterialTypes;
using PuzzleShop.Core;
using PuzzleShop.Core.Commands.MaterialTypes;
using PuzzleShop.Core.Dtos.MaterialTypes;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.MaterialTypes;

// ReSharper disable All

namespace PuzzleShop.Api.Controllers
{
    [AllowAnonymous]
    public class MaterialTypeController : BaseController
    {
        private readonly IRepository<MaterialType> _materialTypeRepository;
        private readonly IMediator _mediator;

        public MaterialTypeController(IRepository<MaterialType> materialTypeRepository, 
            IMapper mapper, IMediator mediator) : base(mapper)
        {
            _materialTypeRepository = materialTypeRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialTypeDto>>> GetMaterialTypes()
        {
            var materialTypes = await _mediator.Send(new GetMaterialTypesQuery());
            return Ok(materialTypes);
        }

        [HttpGet("{materialTypeId}")]
        public async Task<ActionResult<MaterialTypeDto>> GetMaterialType(long materialTypeId)
        {
            var materialType = await _mediator.Send(new GetMaterialTypeQuery {Id = materialTypeId});
            return Ok(materialType);
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpPost]
        public async Task<ActionResult<MaterialTypeDto>> AddMaterialType(
            [FromBody] MaterialTypeCreateModel materialTypeCreateModel)
        {
            var command = _mapper.Map<AddMaterialTypeCommand>(materialTypeCreateModel);
            var materialType = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMaterialType), new {materialTypeId = materialType.Id}, materialType );
        }

        [RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
        [HttpDelete("{materialTypeId}")]
        public async Task<IActionResult> DeleteMaterialType(long materialTypeId)
        {
            await _mediator.Send(new DeleteMaterialTypeCommand {Id = materialTypeId});
            return NoContent();
        }
    }
}