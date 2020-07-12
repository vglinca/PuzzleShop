using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Http;
using PuzzleShop.Core.Dtos.Puzzles;

namespace PuzzleShop.Core.Commands.Puzzles
{
    public class AddPuzzleCommand : IRequest<PuzzleDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsMagnetic { get; set; }
        public double Weight { get; set; }
        public long ManufacturerId { get; set; }
        public long PuzzleTypeId { get; set; }
        public long ColorId { get; set; }
        public long MaterialTypeId { get; set; }
        public uint AvailableInStock { get; set; }
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}