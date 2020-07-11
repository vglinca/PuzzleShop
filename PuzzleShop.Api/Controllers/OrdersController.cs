﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core.Dtos.Customers;
using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Entities;

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
    }
}