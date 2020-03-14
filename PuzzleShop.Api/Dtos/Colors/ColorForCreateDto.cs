using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Dtos.Colors
{
    public class ColorForCreateDto
    {
        [Required]
        public string Title { get; set; }
    }
}