using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Entities;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Controllers
{
	[RoleAuthorize(AuthorizeRole.Administrator, AuthorizeRole.Moderator)]
	public class ManageOrdersController : BaseController
	{
		private readonly IOrderingService _orderingService;

		public ManageOrdersController(IOrderingService orderingService, IMapper mapper) : base(mapper)
		{
			_orderingService = orderingService;
		}

		[HttpPost("ordersPaged")]
		public async Task<IActionResult> GetOrdersPaged([FromBody] PagedRequest request)
		{
			var orders = await _orderingService.GetPagedOrdersAsync(request);
			return Ok(orders);
		}

		[HttpGet("{orderId}")]
		public async Task<IActionResult> GetOrder(long orderId)
		{
			var order = await _orderingService.GetOrderByIdASync(orderId);
			var orderModel = _mapper.Map<OrderDto>(order);
			return Ok(orderModel);
		}

		[HttpPut("orderStatus/{orderId}")]
		public async Task<IActionResult> ChangeOrderStatus(long orderId, [FromBody] OrderStatusForSettingDto statusDto)
		{
			await _orderingService.UpdateOrderStatusAsync(orderId, (OrderStatusId) statusDto.StatusId);

			return NoContent();
		}
	}
}
