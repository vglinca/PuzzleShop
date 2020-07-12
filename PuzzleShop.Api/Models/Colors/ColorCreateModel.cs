using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Models.Colors
{
    public class ColorCreateModel
    {
        [Required(ErrorMessage = "Color title is required.")]
        public string Title { get; set; }
    }
}