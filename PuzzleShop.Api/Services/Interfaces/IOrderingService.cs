using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Api.Services.Interfaces
{
    public interface IOrderingService
    {
        Task<Order> GetOrderByStatusAsync(long userId, OrderStatusId orderStatusId);
        Task<PagedResponse<OrderTableRowDto>> GetPagedOrdersAsync(PagedRequest request);
        Task<IEnumerable<Order>> GetUserOrdersAsync(long userId);
        Task<Order> GetOrderByIdASync(long orderId);
        Task EditCartAsync(OrderItem orderItem, long userId);
        Task UpdateOrderStatusAsync(long orderId, OrderStatusId orderStatusId);
        Task UpdateOrderStatusFromOldOneAsync(long userId, OrderStatusId oldStatus, OrderStatusId newStatus);
        Task RemoveOrderItemAsync(long userId, long itemId);
    }
}