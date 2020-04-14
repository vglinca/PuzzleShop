using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Colors
{
    public class ColorForCreateDto
    {
        [Required(ErrorMessage = "Color title is required.")]
        public string Title { get; set; }
    }
}