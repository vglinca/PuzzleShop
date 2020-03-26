using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public long PuzzleId { get; set; }
        public virtual Puzzle Puzzle { get; set; }
    }
}