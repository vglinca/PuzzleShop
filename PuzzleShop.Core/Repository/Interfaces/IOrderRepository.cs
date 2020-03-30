using System.Collections.Generic;
using System.Threading.Tasks;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Repository.Interfaces
{
    public interface IOrderRepository : IEfCoreRepository<Order>
    {
        Task<Order> FindByUserIdAsync(long userId, OrderStatusId statusId);
        Task<IEnumerable<Order>> FindAllOrdersByUserIdAsync(long userId);
    }
}