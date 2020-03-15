using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Dtos.PuzzleTypes
{
    public class PuzzleTypeForCreationDto
    {
        [Required]
        public string Title { get; set; }
    }
}