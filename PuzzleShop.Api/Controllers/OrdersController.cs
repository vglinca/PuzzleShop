using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderingService _orderingService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper, UserManager<User> userManager, IOrderingService orderingService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _orderingService = orderingService;
        }

        [HttpGet(nameof(GetCart))]
        public async Task<ActionResult<OrderDto>> GetCart()
        {
            var user = await GetCurrentUser();
            var pendingOrder = await _orderingService.GetOrderByStatusAsync(user.Id, OrderStatusId.Pending);

            return Ok(_mapper.Map<OrderDto>(pendingOrder));
        }

        [HttpGet(nameof(GetAllOrders))]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var user = await GetCurrentUser();
            var orders = await _orderingService.GetUserOrdersAsync(user.Id);
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }
        
        [HttpPost(nameof(AddToCart))]
        public async Task<IActionResult> AddToCart([FromBody] OrderItemForCreationDto orderItemForCreationDto)
        {
            var user = await GetCurrentUser();
            
            var orderItem = _mapper.Map<OrderItem>(orderItemForCreationDto);
            await _orderingService.AddToCartAsync(orderItem, user.Id);

            return NoContent();
        }
        
        [HttpPut(nameof(ConfirmOrder))]
        public async Task<IActionResult> ConfirmOrder()
        {
            var user = await GetCurrentUser();

            await _orderingService.UpdateOrderStatusFromOldOneAsync(user.Id, OrderStatusId.Pending,
                OrderStatusId.AwaitingPayment);

            return NoContent();
        }
        
        [HttpPut(nameof(PlaceOrder))]
        public async Task<IActionResult> PlaceOrder([FromBody] UserDataForProcessOrderDto userData)
        {
            //some logic with user data
            var user = await GetCurrentUser();

            await _orderingService.UpdateOrderStatusFromOldOneAsync(user.Id, OrderStatusId.AwaitingPayment,
                OrderStatusId.ConfirmedPayment);

            return NoContent();
        }

        [HttpDelete("removeItemFromOrder/{itemId}")]
        public async Task<IActionResult> RemoveItemFromOrder(long itemId)
        {
            var user = await GetCurrentUser();

            await _orderingService.RemoveOrderItemAsync(user.Id, itemId);
            
            return NoContent();
        }
        
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpGet("getUserOrders/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetUserOrders(long userId)
        {
            var orders = await _orderingService.GetUserOrdersAsync(userId);
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPut("changeOrderStatus/{orderId}")]
        public async Task<IActionResult> ChangeOrderStatus(long orderId, [FromBody] OrderStatusForSettingDto statusDto)
        {
            await _orderingService.UpdateOrderStatusAsync(orderId, (OrderStatusId) statusDto.StatusId);
            
            return NoContent();
        }

        [NonAction]
        private async Task<User> GetCurrentUser()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _userManager.FindByIdAsync(userId);
        }
    }
}