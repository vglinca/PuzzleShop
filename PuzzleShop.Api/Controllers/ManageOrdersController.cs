using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Entities;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PuzzleShop.Api.Models.Orders;
using PuzzleShop.Core.Commands.Orders;
using PuzzleShop.Core.Queries.Orders;

namespace PuzzleShop.Api.Controllers
{
	[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
	public class ManageOrdersController : BaseController
	{
		private readonly IMediator _mediator;

		public ManageOrdersController(IMapper mapper, IMediator mediator) : base(mapper)
		{
			_mediator = mediator;
		}

		[HttpPost("ordersPaged")]
		public async Task<IActionResult> GetOrdersPaged([FromBody] PagedRequest request)
		{
			var orders = await _mediator.Send(new GetPagedOrdersQuery {PagedRequest = request});
			return Ok(orders);
		}

		[HttpGet("{orderId}")]
		public async Task<IActionResult> GetOrder(long orderId)
		{
			var order = await _mediator.Send(new GetOrderQuery {OrderId = orderId});
			var orderModel = _mapper.Map<OrderModel>(order);
			return Ok(orderModel);
		}

		[HttpPut("orderStatus/{orderId}")]
		public async Task<IActionResult> ChangeOrderStatus(long orderId, [FromBody] OrderStatusForSettingDto statusDto)
		{
			await _mediator.Send(new ChangeOrderStatusCommand
				{OrderId = orderId, OrderStatusId = (OrderStatusId) statusDto.StatusId});
			return Ok();
		}
	}
}
