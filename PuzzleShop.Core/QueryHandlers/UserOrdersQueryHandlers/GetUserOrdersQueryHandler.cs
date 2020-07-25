using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Queries.UserOrders;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.QueryHandlers.UserOrdersQueryHandlers
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetUserOrdersQueryHandler(IOrderRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var orderEntities = await _ordersRepository.FindAllOrdersByUserIdAsync(request.UserId);
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orderEntities);
            return orderDtos;
        }
    }
}