using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.Images;

namespace PuzzleShop.Core.Queries.Images
{
    public class GetImagesQuery : IRequest<IEnumerable<ImageDto>>
    {
        public long PuzzleId { get; set; }
    }
}