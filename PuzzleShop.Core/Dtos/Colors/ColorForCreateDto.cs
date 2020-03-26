using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Colors
{
    public class ColorForCreateDto
    {
        [Required]
        public string Title { get; set; }
    }
}