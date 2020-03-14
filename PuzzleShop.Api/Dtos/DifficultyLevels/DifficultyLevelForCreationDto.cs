using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Dtos.DifficultyLevels
{
    public class DifficultyLevelForCreationDto
    {
        [Required]
        public string Title { get; set; }
    }
}