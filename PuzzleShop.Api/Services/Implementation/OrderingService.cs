using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PuzzleShop.Api.Helpers;
using PuzzleShop.Api.Services.Interfaces;
using PuzzleShop.Core;
using PuzzleShop.Core.Dtos.Customers;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using Stripe;

namespace PuzzleShop.Api.Services.Implementation
{
    public class OrderingService : IOrderingService
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IRepository<Domain.Entities.OrderItem> _orderItemRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly StripeApiSecret _stripeApiSecret;

        public OrderingService(IOrderRepository orderRepository, 
            IRepository<Domain.Entities.OrderItem> orderItemRepository, 
            IMapper mapper, 
            IConfiguration configuration,
            IPuzzleRepository puzzleRepository,
            IOptions<StripeApiSecret> stripeApiSecret)
        {
            _ordersRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
            _configuration = configuration;
            _puzzleRepository = puzzleRepository;
            _stripeApiSecret = stripeApiSecret.Value;
        }

        public async Task<Domain.Entities.Order> GetOrderByStatusAsync(long userId, OrderStatusId orderStatusId)
        {
            return await _ordersRepository.FindByUserIdAndStatusAsync(userId, orderStatusId);
        }

        public async Task<PagedResponse<OrderTableRowDto>> GetPagedOrdersAsync(PagedRequest request)
        {
            return await _ordersRepository.GetPagedOrders(request, _mapper);
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetUserOrdersAsync(long userId)
        {
            return await _ordersRepository.FindAllOrdersByUserIdAsync(userId);
        }

        public async Task<Domain.Entities.Order> GetOrderByIdASync(long orderId)
        {
            return await _ordersRepository.FindByIdAsync(orderId);
        }

        public async Task EditCartAsync(Domain.Entities.OrderItem orderItem, long userId)
        {
            var order = await _ordersRepository.FindByUserIdAndStatusAsync(userId, OrderStatusId.Pending);
            if (order == null)
            {
                order = new Domain.Entities.Order
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

        public async Task ConfirmOrderAsync(long userId, CustomerInfoForOrderDto customerDetails)
        {
            //a user can have only one pending order
            var pendingOrder = await _ordersRepository.FindByUserIdAndStatusAsync(userId, OrderStatusId.Pending);
            _mapper.Map(customerDetails, pendingOrder);
            
            // pendingOrder.ContactEmail = customerDetails.ContactEmail;
            // pendingOrder.CustomerFirstName = customerDetails.CustomerFirstName;
            // pendingOrder.CustomerLastName = customerDetails.CustomerLastName;
            // pendingOrder.Address = customerDetails.Address;
            // pendingOrder.City = customerDetails.City;
            // pendingOrder.Country = customerDetails.Country;
            // pendingOrder.PostalCode = customerDetails.PostalCode;
            // pendingOrder.Phone = customerDetails.Phone;

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

        public async Task CheckoutAsync(long userId, long orderId, CustomerInfoForOrderDto customerInfo)
        {
            var order = await _ordersRepository.FindByIdAsync(orderId);
            _mapper.Map(customerInfo, order);
            // order.ContactEmail = customerInfo.ContactEmail;
            // order.CustomerFirstName = customerInfo.CustomerFirstName;
            // order.CustomerLastName = customerInfo.CustomerLastName;
            // order.Address = customerInfo.Address;
            // order.City = customerInfo.City;
            // order.Country = customerInfo.Country;
            // order.PostalCode = customerInfo.PostalCode;
            // order.Phone = customerInfo.Phone;
            var apiKey = _configuration.GetValue<string>("StripeSecret");
            StripeConfiguration.ApiKey = apiKey;
            try
            {
                var customerOptions = new CustomerCreateOptions
                {
                    Source = customerInfo.Token,
                    Email = customerInfo.ContactEmail,
                    Name = $"{customerInfo.CustomerFirstName} {customerInfo.CustomerLastName}",
                    Phone = customerInfo.Phone,
                    Metadata = new Dictionary<string, string>()
                {
                    {"City", customerInfo.City },
                    {"Country", customerInfo.Country },
                    {"Address", customerInfo.Address}
                }
                };
                var customerService = new CustomerService();
                var customer = await customerService.CreateAsync(customerOptions);

                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = ((long) order.TotalCost) * 100,
                    Description = $"Charge for {customerInfo.ContactEmail}",
                    Customer = customer.Id,
                    Currency = "USD"
                };

                var chargeService = new ChargeService();
                var charge = await chargeService.CreateAsync(chargeOptions);

                foreach (var orderItem in order.OrderItems)
                {
                    var puzzle = await _puzzleRepository.FindByIdAsync(orderItem.PuzzleId);
                    if(puzzle.AvailableInStock >= orderItem.Quantity)
                    {
                        puzzle.AvailableInStock -= orderItem.Quantity;
                        await _puzzleRepository.UpdateEntityAsync(puzzle);                    
                    }
                }

                order.OrderStatusId = OrderStatusId.ConfirmedPayment;
                await _ordersRepository.UpdateEntityAsync(order);
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException("An error occured during payment process.");
            }
        }
    }
}