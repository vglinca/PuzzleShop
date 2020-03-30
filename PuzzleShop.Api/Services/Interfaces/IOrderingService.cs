using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Services.Interfaces
{
    public interface IOrderingService
    {
        Task<Order> GetOrderByStatusAsync(long userId, OrderStatusId orderStatusId);
        Task<IEnumerable<Order>> GetUserOrdersAsync(long userId);
        Task AddToCartAsync(OrderItem orderItem, long userId);
        Task UpdateOrderStatusAsync(long orderId, OrderStatusId orderStatusId);
        Task UpdateOrderStatusFromOldOneAsync(long userId, OrderStatusId oldStatus, OrderStatusId newStatus);
        Task RemoveOrderItemAsync(long userId, long itemId);
    }
}