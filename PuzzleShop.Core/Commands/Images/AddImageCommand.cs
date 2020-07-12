using MediatR;
using Microsoft.AspNetCore.Http;

namespace PuzzleShop.Core.Commands.Images
{
    public class AddImageCommand : IRequest<Unit>
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public IFormFile File { get; set; }
        public long PuzzleId { get; set; }
    }
}