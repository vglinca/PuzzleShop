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
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Core.Dtos.Orders;
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
        private readonly IOrderRepository _ordersRepository;
        private readonly IRepository<OrderItem> _orderItemsRepository;
        private readonly IRepository<OrderStatus> _orderStatusRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository ordersRepository, IMapper mapper, UserManager<User> userManager, IRepository<OrderItem> orderItemsRepository, IRepository<OrderStatus> orderStatusRepository)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _userManager = userManager;
            _orderItemsRepository = orderItemsRepository;
            _orderStatusRepository = orderStatusRepository;
        }

        [HttpGet(nameof(GetPendingOrder))]
        public async Task<ActionResult<OrderDto>> GetPendingOrder()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            var pendingOrder = await _ordersRepository.FindByUserIdAsync(user.Id, OrderStatusId.Pending);

            return Ok(_mapper.Map<OrderDto>(pendingOrder));
        }

        [HttpGet(nameof(GetOrders))]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            var orders = await _ordersRepository.FindAllOrdersByUserId(user.Id);
            orders = orders.Where(o => o.OrderStatusId != OrderStatusId.Pending);
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpGet("getUserOrders/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetUserOrders(long userId)
        {
            var orders = await _ordersRepository.FindAllOrdersByUserId(userId);
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "moderator")]
        [HttpPut("changeOrderStatus/{orderId}")]
        public async Task<IActionResult> ChangeOrderStatus(long orderId, [FromBody] long statusId)
        {
            var order = await _ordersRepository.FindByIdAsync(orderId);
            var status = await _orderStatusRepository.FindByIdAsync(statusId);
            order.OrderStatusId = status.OrderStatusId;
            await _ordersRepository.UpdateEntityAsync(order);
            
            return NoContent();
        }

        [HttpPost(nameof(AddToCart))]
        public async Task<IActionResult> AddToCart([FromBody] OrderItemForCreationDto orderItemForCreationDto)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            
            var orderItem = _mapper.Map<OrderItem>(orderItemForCreationDto);
           
            var order = await _ordersRepository.FindByUserIdAsync(user.Id, OrderStatusId.Pending);
            if (order == null)
            {
                order = new Order
                {
                    OrderStatusId = OrderStatusId.Pending,
                    OrderDate = DateTimeOffset.Now,
                    UserId = user.Id,
                    TotalCost = 0,
                    TotalItems = 0
                };
                
                order.TotalCost += orderItem.Cost;
                order.TotalItems++;

                await _ordersRepository.AddEntityAsync(order);
            } else
            {
                order.TotalCost += orderItem.Cost;
                order.TotalItems++;

                await _ordersRepository.UpdateEntityAsync(order);
            }
            orderItem.OrderId = order.Id;
            await _orderItemsRepository.AddEntityAsync(orderItem);
            
            return NoContent();
        }

        [HttpDelete("removeItemFromOrder/{itemId}")]
        public async Task<IActionResult> RemoveItemFromOrder(long itemId)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            var order = await _ordersRepository.FindByUserIdAsync(user.Id, OrderStatusId.Pending);

            var orderItem = await _orderItemsRepository.FindByIdAsync(itemId);
            await _orderItemsRepository.DeleteEntityAsync(orderItem);

            order.TotalItems--;
            order.TotalCost -= orderItem.Cost;

            if (order.TotalItems > 0)
            {
                await _ordersRepository.UpdateEntityAsync(order);
            } else
            {
                await _ordersRepository.DeleteEntityAsync(order);
            }
            return NoContent();
        }
    }
}