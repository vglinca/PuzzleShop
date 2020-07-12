using MediatR;

namespace PuzzleShop.Core.Commands.Puzzles
{
    public class UpdatePuzzleCommand : IRequest<Unit>
    {
        public long PuzzleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMagnetic { get; set; }
        public long ManufacturerId { get; set; }
        public long PuzzleTypeId { get; set; }
        public long ColorId { get; set; }
        public long MaterialTypeId { get; set; }
        public double? Rating { get; set; }
        public uint AvailableInStock { get; set; }
        public double Weight { get; set; }
    }
}