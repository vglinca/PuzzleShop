using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.Colors;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.ColorsCommandHandlers
{
    public class AddColorCommandHandler : IRequestHandler<AddColorCommand, ColorDto>
    {
        private readonly IRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public AddColorCommandHandler(IRepository<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<ColorDto> Handle(AddColorCommand request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.AddEntityAsync(_mapper.Map(request, new Color()));
            var colorDto = _mapper.Map<ColorDto>(color);
            return colorDto;
        }
    }
}