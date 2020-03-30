using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.DbContext;

namespace PuzzleShop.Core.Repository.Impl
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PuzzleShopContext _ctx;

        public OrderRepository(PuzzleShopContext ctx)
        {
            _ctx = ctx;
        }

        public void Dispose()
        {
        }

        public async Task<Order> FindByIdAsync(long id)
        {
            var entity = await _ctx.FindAsync<Order>(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(
                    $"{typeof(Order).ToString().Split('.').Last()} with Id {id} not found.");
            }
            return entity;
        }

        public async Task<Order> AddEntityAsync(Order entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
            }
            _ctx.Set<Order>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateEntityAsync(Order entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
            }

            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(Order entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} is null.");
            }

            var entityToDel = _ctx.FindAsync<Order>(entity.Id);
            if (entityToDel == null)
            {
                throw new EntityNotFoundException(
                    $"{typeof(Order).ToString().Split('.').Last()} with Id {entity.Id} not found.");
            }
            _ctx.Set<Order>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Order> FindByUserIdAsync(long userId, OrderStatusId statusId)
        {
            var order = await _ctx.Orders
                .FirstOrDefaultAsync(o => o.UserId == userId && o.OrderStatusId == statusId);
            if (order == null)
            {
                throw new EntityNotFoundException($"Order not found.");
            }

            return order;
        }

        public async Task<IEnumerable<Order>> FindAllOrdersByUserIdAsync(long userId)
        {
            var orders = await _ctx.Orders
                .Where(o => o.UserId == userId).ToListAsync();
            return orders;
        }
    }
}