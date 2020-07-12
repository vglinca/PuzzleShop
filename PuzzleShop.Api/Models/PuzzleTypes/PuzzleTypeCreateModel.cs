using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Models.PuzzleTypes
{
    public class PuzzleTypeCreateModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "IsRubicsCube field is required.")]
        public bool IsRubicsCube { get; set; }

        [Required(ErrorMessage = "IsWca field is required.")]
        public bool IsWca { get; set; }

        [Required(ErrorMessage = "DifficultyLevelId is required.")]
        public long DifficultyLevelId { get; set; }
    }
}