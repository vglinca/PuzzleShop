using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PuzzleShop.Core.Commands.Colors;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.ColorsCommandHandlers
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, Unit>
    {
        private readonly IRepository<Color> _colorRepository;

        public DeleteColorCommandHandler(IRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<Unit> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var colorToDelete = await _colorRepository.FindByIdAsync(request.Id);
            await _colorRepository.DeleteEntityAsync(colorToDelete);
            return Unit.Value;
        }
    }
}