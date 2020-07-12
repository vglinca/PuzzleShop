using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.PaginationModels;
using PuzzleShop.Core.Queries.Orders;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.QueryHandlers.OrdersQueryHandlers
{
    public class OrdersQueryHandler : 
        IRequestHandler<GetPagedOrdersQuery, PagedResponse<OrderTableRowDto>>,
        IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>,
        IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IMapper _mapper;

        public OrdersQueryHandler(IOrderRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<OrderTableRowDto>> Handle(GetPagedOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _ordersRepository.GetPagedOrders(request.PagedRequest, _mapper);
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _ordersRepository.FindAllOrdersByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.FindByIdAsync(request.OrderId);
            return _mapper.Map<OrderDto>(order);
        }
    }
}