using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PuzzleShop.Core.Commands.MaterialTypes;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.CommandHandlers.MaterialTypesCommandHandlers
{
    public class DeleteMaterialTypeCommandHandler : IRequestHandler<DeleteMaterialTypeCommand, Unit>
    {
        private readonly IRepository<MaterialType> _materialTypeRepository;

        public DeleteMaterialTypeCommandHandler(IRepository<MaterialType> materialTypeRepository)
        {
            _materialTypeRepository = materialTypeRepository;
        }

        public async Task<Unit> Handle(DeleteMaterialTypeCommand request, CancellationToken cancellationToken)
        {
            var materialTypeToDelete = await _materialTypeRepository.FindByIdAsync(request.Id);
            await _materialTypeRepository.DeleteEntityAsync(materialTypeToDelete);
            return Unit.Value;
        }
    }
}