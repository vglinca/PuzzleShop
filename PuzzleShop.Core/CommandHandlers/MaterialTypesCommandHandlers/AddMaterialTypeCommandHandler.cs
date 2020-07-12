using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PuzzleShop.Core.Commands.MaterialTypes;
using PuzzleShop.Core.Dtos.MaterialTypes;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.MaterialTypesCommandHandlers
{
    public class AddMaterialTypeCommandHandler : IRequestHandler<AddMaterialTypeCommand, MaterialTypeDto>
    {
        private readonly IRepository<MaterialType> _materialTypeRepository;
        private readonly IMapper _mapper;

        public AddMaterialTypeCommandHandler(IRepository<MaterialType> materialTypeRepository, IMapper mapper)
        {
            _materialTypeRepository = materialTypeRepository;
            _mapper = mapper;
        }

        public async Task<MaterialTypeDto> Handle(AddMaterialTypeCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd = _mapper.Map<MaterialType>(request);
            await _materialTypeRepository.AddEntityAsync(entityToAdd);
            return _mapper.Map<MaterialTypeDto>(entityToAdd);
        }
    }
}