using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<PagedResponse<OrderTableRowDto>> GetPagedOrders(PagedRequest request, IMapper mapper);
        Task<Order> FindByUserIdAndStatusAsync(long userId, OrderStatusId statusId);
        Task<IEnumerable<Order>> FindAllOrdersByUserIdAsync(long userId);
    }
}