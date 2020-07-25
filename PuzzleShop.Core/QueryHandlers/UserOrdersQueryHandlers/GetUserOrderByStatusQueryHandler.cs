using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Queries.UserOrders;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.QueryHandlers.UserOrdersQueryHandlers
{
    public class GetUserOrderByStatusQueryHandler : IRequestHandler<GetUserOrderByStatusQuery, OrderDto>
    {
        private readonly IOrderRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetUserOrderByStatusQueryHandler(IOrderRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetUserOrderByStatusQuery request, CancellationToken cancellationToken)
        {
            var orderEntity = await _ordersRepository.FindByUserIdAndStatusAsync(request.UserId, request.OrderStatusId);
            var orderDto = _mapper.Map<OrderDto>(orderEntity);
            return orderDto;
        }
    }
}