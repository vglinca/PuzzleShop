using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Dtos.MaterialTypes;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Queries.MaterialTypes;

namespace PuzzleShop.Core.QueryHandlers.MaterialTypesQueryHandlers
{
    public class MaterialTypeQueryHandler : 
        IRequestHandler<GetMaterialTypesQuery, IEnumerable<MaterialTypeDto>>,
        IRequestHandler<GetMaterialTypeQuery, MaterialTypeDto>
    {
        private readonly IRepository<MaterialType> _materialTypeRepository;
        private readonly IMapper _mapper;

        public MaterialTypeQueryHandler(IRepository<MaterialType> materialTypeRepository, IMapper mapper)
        {
            _materialTypeRepository = materialTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialTypeDto>> Handle(GetMaterialTypesQuery request, CancellationToken cancellationToken)
        {
            var materialTypes = await _materialTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialTypeDto>>(materialTypes);
        }

        public async Task<MaterialTypeDto> Handle(GetMaterialTypeQuery request, CancellationToken cancellationToken)
        {
            var materialType = await _materialTypeRepository.FindByIdAsync(request.Id);
            return _mapper.Map<MaterialTypeDto>(materialType);
        }
    }
}