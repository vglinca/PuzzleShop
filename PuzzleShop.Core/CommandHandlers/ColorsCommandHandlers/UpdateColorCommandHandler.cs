using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.Colors;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.ColorsCommandHandlers
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, Unit>
    {
        private readonly IRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IRepository<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.FindByIdAsync(request.Id);
            _mapper.Map(request, color);
            await _colorRepository.UpdateEntityAsync(color);
            return Unit.Value;
        }
    }
}