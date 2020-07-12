using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PuzzleShop.Core.Commands.Orders;
using PuzzleShop.Core.Repository.Interfaces;

namespace PuzzleShop.Core.CommandHandlers.OrderCommandHandlers
{
    public class OrderCommandHandler : IRequestHandler<ChangeOrderStatusCommand, Unit>
    {
        private readonly IOrderRepository _ordersRepository;

        public OrderCommandHandler(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Unit> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.FindByIdAsync(request.OrderId);
            order.OrderStatusId = request.OrderStatusId;
            order.OrderStatusTitle = request.OrderStatusId.ToString();
            await _ordersRepository.UpdateEntityAsync(order);
            return Unit.Value;
        }
    }
}