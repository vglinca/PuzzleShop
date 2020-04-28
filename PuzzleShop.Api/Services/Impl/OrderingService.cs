﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Customers;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Services.Impl
{
    public class OrderingService : IOrderingService
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderingService(IOrderRepository orderRepository, IRepository<OrderItem> orderItemRepository, IMapper mapper)
        {
            _ordersRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<Order> GetOrderByStatusAsync(long userId, OrderStatusId orderStatusId)
        {
            return await _ordersRepository.FindByUserIdAndStatusAsync(userId, orderStatusId);
        }

        public async Task<PagedResponse<OrderTableRowDto>> GetPagedOrdersAsync(PagedRequest request)
        {
            return await _ordersRepository.GetPagedOrders(request, _mapper);
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(long userId)
        {
            return await _ordersRepository.FindAllOrdersByUserIdAsync(userId);
        }

        public async Task<Order> GetOrderByIdASync(long orderId)
        {
            return await _ordersRepository.FindByIdAsync(orderId);
        }

        public async Task EditCartAsync(OrderItem orderItem, long userId)
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
                    //first substract order items quantity. We can't just make addition 
                    //because orderItem's quantity can be less than existingOrderItem's one 
                    //same logic with TotalCost
                    order.TotalItems -= existingOrderItem.Quantity;
                    order.TotalItems += orderItem.Quantity;

                    order.TotalCost -= existingOrderItem.Cost;
                    order.TotalCost += orderItem.Cost;

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
                    order.TotalItems += orderItem.Quantity;
                    order.TotalCost += orderItem.Cost;
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

        public async Task UpdateOrderStatusAsync(long userId, OrderStatusId oldStatus, OrderStatusId newStatus)
        {
            var orderWithOldStatus = await _ordersRepository.FindByUserIdAndStatusAsync(userId, oldStatus);
            orderWithOldStatus.OrderStatusId = newStatus;

            await _ordersRepository.UpdateEntityAsync(orderWithOldStatus);
        }

        public async Task CheckoutOrderAsync(long userId, CustomerInfoForOrderDto customerDetails)
        {
            //a user can have only one pending order
            var pendingOrder = await _ordersRepository.FindByUserIdAndStatusAsync(userId, OrderStatusId.Pending);
            
            pendingOrder.ContactEmail = customerDetails.ContactEmail;
            pendingOrder.CustomerFirstName = customerDetails.CustomerFirstName;
            pendingOrder.CustomerLastName = customerDetails.CustomerLastName;
            pendingOrder.Address = customerDetails.Address;
            pendingOrder.City = customerDetails.City;
            pendingOrder.Country = customerDetails.Country;
            pendingOrder.PostalCode = customerDetails.PostalCode;
            pendingOrder.Phone = customerDetails.Phone;

            pendingOrder.OrderStatusId = OrderStatusId.AwaitingPayment;

            await _ordersRepository.UpdateEntityAsync(pendingOrder);
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