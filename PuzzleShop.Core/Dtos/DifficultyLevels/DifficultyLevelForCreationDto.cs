using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.DifficultyLevels
{
    public class DifficultyLevelForCreationDto
    {
        [Required]
        public string Title { get; set; }
    }
}