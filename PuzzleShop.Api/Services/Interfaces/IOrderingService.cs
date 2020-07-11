using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Core.Dtos.Customers;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.PaginationModels;

namespace PuzzleShop.Api.Services.Interfaces
{
    public interface IOrderingService
    {
        Task<Order> GetOrderByStatusAsync(long userId, OrderStatusId orderStatusId);
        Task<PagedResponse<OrderTableRowDto>> GetPagedOrdersAsync(PagedRequest request);
        Task<IEnumerable<Order>> GetUserOrdersAsync(long userId);
        Task<Order> GetOrderByIdASync(long orderId);
        Task EditCartAsync(OrderItem orderItem, long userId, int? addedFromCollections = null);
        Task UpdateOrderStatusAsync(long orderId, OrderStatusId orderStatusId);
        Task ConfirmOrderAsync(long userId, CustomerInfoForOrderDto customerDetails);
        Task CheckoutAsync(long userId, long orderId, CustomerInfoForOrderDto customerInfo);
        Task UpdateOrderStatusAsync(long userId, OrderStatusId oldStatus, OrderStatusId newStatus);
        Task RemoveOrderItemAsync(long userId, long itemId);
    }
}