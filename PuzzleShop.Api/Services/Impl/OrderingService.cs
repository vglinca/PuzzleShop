using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Services.Impl
{
    public class OrderingService : IOrderingService
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderingService(IOrderRepository orderRepository, IRepository<OrderItem> orderItemRepository)
        {
            _ordersRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Order> GetOrderByStatusAsync(long userId, OrderStatusId orderStatusId)
        {
            return await _ordersRepository.FindByUserIdAndStatusAsync(userId, orderStatusId);
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(long userId)
        {
            return await _ordersRepository.FindAllOrdersByUserIdAsync(userId);
        }

        public async Task<Order> GetOrderByIdASync(long orderId)
        {
            return await _ordersRepository.FindByIdAsync(orderId);
        }

        public async Task AddToCartAsync(OrderItem orderItem, long userId)
        {
            var order = await _ordersRepository.FindByUserIdAndStatusAsync(userId, OrderStatusId.Pending);
            if (order == null)
            {
                order = new Order
                {
                    OrderStatusId = OrderStatusId.Pending,
                    OrderDate = DateTimeOffset.Now,
                    UserId = userId,
                    TotalCost = 0,
                    TotalItems = 0
                };
                
                order.TotalCost += orderItem.Cost;
                order.TotalItems += orderItem.Quantity;

                await _ordersRepository.AddEntityAsync(order);
                orderItem.OrderId = order.Id;
                await _orderItemRepository.AddEntityAsync(orderItem);
            } 
            else
            {
                var existingOrderItem = order.OrderItems.FirstOrDefault(item => item.PuzzleId == orderItem.PuzzleId);
                if(existingOrderItem != null)
                {
                    existingOrderItem.Quantity = orderItem.Quantity;
                    if(existingOrderItem.Quantity == 0)
                    {
                        await _orderItemRepository.DeleteEntityAsync(existingOrderItem);
                    }
                    else
                    {
                        existingOrderItem.Cost = orderItem.Cost;
                        await _orderItemRepository.UpdateEntityAsync(existingOrderItem);
                    }
                }
                else
                {
                    orderItem.OrderId = order.Id;
                    await _orderItemRepository.AddEntityAsync(orderItem);
                }

                await _ordersRepository.UpdateEntityAsync(order);
            }
        }

        public async Task UpdateOrderStatusAsync(long orderId, OrderStatusId orderStatusId)
        {
            var order = await _ordersRepository.FindByIdAsync(orderId);
            order.OrderStatusId = orderStatusId;
            await _ordersRepository.UpdateEntityAsync(order);
        }

        public async Task UpdateOrderStatusFromOldOneAsync(long userId, OrderStatusId oldStatus, OrderStatusId newStatus)
        {
            var orderWithOldStatus = await _ordersRepository.FindByUserIdAndStatusAsync(userId, oldStatus);
            orderWithOldStatus.OrderStatusId = newStatus;

            await _ordersRepository.UpdateEntityAsync(orderWithOldStatus);
        }

        public async Task RemoveOrderItemAsync(long userId, long itemId)
        {
            var order = await _ordersRepository.FindByUserIdAndStatusAsync(userId, OrderStatusId.Pending);
            
            var orderItem = await _orderItemRepository.FindByIdAsync(itemId);
            await _orderItemRepository.DeleteEntityAsync(orderItem);

            if (order.OrderItems.Any())
            {
                await _ordersRepository.UpdateEntityAsync(order);
            } else
            {
                await _ordersRepository.DeleteEntityAsync(order);
            }
        }

       
    }
}