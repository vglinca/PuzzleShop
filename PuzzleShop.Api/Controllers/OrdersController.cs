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
using PuzzleShop.Core.Dtos.Customers;
using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Dtos.Users;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Domain.Entities.Auth;

namespace PuzzleShop.Api.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrderingService _orderingService;

        public OrdersController(IMapper mapper, 
            IOrderingService orderingService) : base(mapper)
        {
            _orderingService = orderingService;
        }

        [HttpGet("getCart/{userId}")]
        public async Task<IActionResult> GetCart(long userId)
        {
            var pendingOrder = await _orderingService.GetOrderByStatusAsync(userId, OrderStatusId.Pending);

            return Ok(_mapper.Map<OrderDto>(pendingOrder));
        }

        [HttpGet("orders/{userId}")]
        public async Task<IActionResult> GetAllOrders(long userId)
        {
            var orders = await _orderingService.GetUserOrdersAsync(userId);
            var models = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(models);
        }
        
        [HttpPost(nameof(AddToCart))]
        public async Task<IActionResult> AddToCart([FromBody] OrderItemForCreationDto orderItemForCreationDto, [FromQuery] int addedFromCollections)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemForCreationDto);
            await _orderingService.EditCartAsync(orderItem, orderItemForCreationDto.UserId, addedFromCollections);

            return Ok();
        }
        
        [HttpPut("confirmOrder/{userId}")]
        public async Task<IActionResult> ConfirmOrder(long userId, [FromBody] CustomerInfoForOrderDto customerDetails)
        {
            await _orderingService.ConfirmOrderAsync(userId, customerDetails);

            return NoContent();
        }
        
        [HttpPut("placeOrder/{userId}/{orderId}")]
        public async Task<IActionResult> PlaceOrder(long userId, long orderId, [FromBody] CustomerInfoForOrderDto userData)
        {
            await _orderingService.CheckoutAsync(userId, orderId, userData);
            return Ok();
        }

        [HttpDelete("orderItem/{userId}/{itemId}")]
        public async Task<IActionResult> RemoveOrderItem(long userId, long itemId)
        {
            await _orderingService.RemoveOrderItemAsync(userId, itemId);
            
            return NoContent();
        }
        
        //[NonAction]
        //private async Task<User> GetCurrentUser()
        //{
        //    var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    return await _userManager.FindByIdAsync(userId);
        //}
    }
}