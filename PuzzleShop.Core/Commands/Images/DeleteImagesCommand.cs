using System.Collections.Generic;
using MediatR;

namespace PuzzleShop.Core.Commands.Images
{
    public class DeleteImagesCommand : IRequest<Unit>
    {
        public long PuzzleId { get; set; }
        public IEnumerable<long> ImageIds { get; set; }
    }
}