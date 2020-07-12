using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.Colors;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.Colors;

namespace PuzzleShop.Core.QueryHandlers.ColorsQueryHandlers
{
    public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, IEnumerable<ColorDto>>
    {
        private readonly IRepository<Color> _colorRepository;
        private readonly IMapper _mapper;

        public GetColorsQueryHandler(IRepository<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ColorDto>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
        {
            var colors = await _colorRepository.GetAllAsync();
            var projectedColors = _mapper.Map<IEnumerable<ColorDto>>(colors);
            return projectedColors;
        }
    }
}