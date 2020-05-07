using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Exceptions;
using PuzzleShop.Core.Extensions;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Repository.Interfaces;
using PuzzleShop.Domain.Entities;
using PuzzleShop.Persistance.DbContext;

namespace PuzzleShop.Core.Repository.Implementation
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

        public async Task<PagedResponse<OrderTableRowDto>> GetPagedOrders(PagedRequest request, IMapper mapper)
        {
            //pending and non-confirmed orders can not be seen by admin. So thus he won't be able to change their status.
            var orders = _ctx.Orders
                .Where(o => o.OrderStatusId != OrderStatusId.Pending);
            return await orders.CreatePagedResultAsync<Order, OrderTableRowDto>(request, mapper);
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

        public async Task<Order> FindByUserIdAndStatusAsync(long userId, OrderStatusId statusId)
        {
            var order = await _ctx.Orders
                .FirstOrDefaultAsync(o => o.UserId == userId && o.OrderStatusId == statusId);
            if (order == null && statusId != OrderStatusId.Pending)
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

        public async Task<IEnumerable<Order>> GetAllAsync(params Expression<Func<Order, bool>>[] wherePredicate)
        {
            var orders = _ctx.Set<Order>().AsQueryable();
            return await orders.ToListAsync();
        }
    }
}