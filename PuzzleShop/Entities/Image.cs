using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable All

namespace PuzzleShop.Entities
{
    public class Image : BaseEntity
    {
        public string? Title { get; set; }
        [Required]
        public string FileName { get; set; }
        public long PuzzleId { get; set; }
        [ForeignKey(nameof(PuzzleId))]
        public Puzzle Puzzle { get; set; }
    }
}