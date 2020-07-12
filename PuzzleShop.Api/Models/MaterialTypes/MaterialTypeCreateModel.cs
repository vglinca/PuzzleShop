using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Models.MaterialTypes
{
    public class MaterialTypeCreateModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
    }
}