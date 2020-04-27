using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleShop.Api.Controllers
{
	//[Authorize(Roles = "admin")]
	//[Authorize(Roles = "moderator")]
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class ManageOrdersController : ControllerBase
	{
		private readonly IOrderingService _orderingService;
		private readonly IMapper _mapper;

		public ManageOrdersController(IOrderingService orderingService, IMapper mapper)
		{
			_orderingService = orderingService;
			_mapper = mapper;
		}

		[HttpPost("getOrdersPaged")]
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
