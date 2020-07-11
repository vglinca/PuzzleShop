
// ReSharper disable All

namespace PuzzleShop.Core.Entities
{
    public class Image : BaseEntity
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public long PuzzleId { get; set; }
        public virtual Puzzle Puzzle { get; set; }
    }
}